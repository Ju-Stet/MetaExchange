﻿using MetaExchange.Models;
using MetaExchange.Services.Converters;
using MetaExchange.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MetaExchange.Services
{
    public class InputDataService : IInputDataService
    {
        private List<IdOrderBookDTO> idOrderBookDTOs = new List<IdOrderBookDTO>();
        static readonly Regex pattern = new Regex(@"(?<key>\d+\.+\d+)[\t*|\s*](?<value>\{(.+|\t +|\s +))");

        public ServiceResult ProcessOrderBooksDataFilePath(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new ServiceResult("Empty order book data file path");
            }
            try
            {
                return CreateIdOrderBookDTOList(input);
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex.Message);
            }
        }

        public ServiceResult ProcessCurrencyAmount(string currencyAmount)
        {
            if (string.IsNullOrEmpty(currencyAmount) || !Decimal.TryParse(currencyAmount, out decimal result))
            {
                return new ServiceResult("Unknown currency amount type");
            }

            return new ServiceObjectResult<decimal>(result);
        }


        private ServiceResult CreateIdOrderBookDTOList(string input)
        {
            try
            {
                var orderBooksString = File.ReadAllText(input);

                var matches = pattern.Matches(orderBooksString);

                foreach (Match match in matches)
                {
                    var serializer = JsonSerializer.Create(Converter.Settings);
                    var jsonReader = new JsonTextReader(new StringReader(match.Groups["value"].Value));
                    var orderBook = serializer.Deserialize<OrderBookDTO>(jsonReader);
                    idOrderBookDTOs.Add(new IdOrderBookDTO()
                    {
                        ID = match.Groups["key"].Value,
                        OrderBook = orderBook
                    });
                }
                return new ServiceObjectResult<List<IdOrderBookDTO>>(idOrderBookDTOs);
            }
            catch (Exception)
            {
                return new ServiceResult("Could not find the file or read data from file");
            }
        }
    }
}
