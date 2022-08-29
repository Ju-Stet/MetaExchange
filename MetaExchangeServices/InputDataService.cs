using MetaExchange.Models;
using MetaExchange.Services.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaExchange.Services
{
    public class InputDataService : IInputDataService
    {
        private Dictionary<string, OrderBook> orderBookDictionary = new Dictionary<string, OrderBook>();
        static readonly Regex pattern = new Regex(@"(?<key>\d+\.+\d+)[\t*|\s*](?<value>\{(.+|\t +|\s +))");

        public async Task<ServiceResult> ProcessOrderBooksDataFilePathAsync(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new ServiceResult("Empty order book data file path");
            }
            try
            {
                return await CreateOrderBookDictionary(input);
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex.Message);
            }
        }

        public ServiceResult ProcessCurrencyAmount(string currencyAmount)
        {
            if (string.IsNullOrEmpty(currencyAmount) || !Double.TryParse(currencyAmount, out double result))
            {
                return new ServiceResult("Unknown currency amount type");
            }

            return new ServiceObjectResult<double>(result);
        }


        private async Task<ServiceResult> CreateOrderBookDictionary(string input)
        {
            try
            {
                var orderBooksString = await File.ReadAllTextAsync(input);

                var matches = pattern.Matches(orderBooksString);

                foreach (Match match in matches)
                {
                    var serializer = JsonSerializer.Create(Converter.Settings);
                    var jsonReader = new JsonTextReader(new StringReader(match.Groups["value"].Value));
                    var orderBook = serializer.Deserialize<OrderBook>(jsonReader);
                    orderBookDictionary.Add(match.Groups["key"].Value, orderBook);
                }
                return new ServiceObjectResult<Dictionary<string, OrderBook>>(orderBookDictionary);
            }
            catch (Exception)
            {
                return new ServiceResult("Could not find the file or read data from file");
            }
        }
    }
}
