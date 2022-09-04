using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetaExchange.Services
{
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderService _orderService;
        private readonly IInputDataService _inputDataService;
        private readonly IExchangeMapper _exchangeMapper;
        public OrderBookService(IOrderService orderService,
            IInputDataService inputDataService,
            IExchangeMapper exchangeMapper)
        {
            _orderService = orderService;
            _inputDataService = inputDataService;
            _exchangeMapper = exchangeMapper;
        }

        public ServiceResult FindBestFit(RequestInfo requestInfo,
            List<ExchangeDTO> exchangeDTOs = null)
        {
            if (exchangeDTOs == null)
            {
                string path = GetOrderBookFilePath();
                var serviceResult = _inputDataService.ProcessOrderBooksDataFilePath(path) as ServiceObjectResult<List<ExchangeDTO>>;
                exchangeDTOs = serviceResult.Value;
            }

            exchangeDTOs = _exchangeMapper.MapRequestInfoOntoExchangeDTOList(requestInfo, exchangeDTOs);
            List<GetOrderResponse> orderResponses = new List<GetOrderResponse>();

            if (requestInfo.OrderType == OrderTypeEnum.Sell)
            {
                foreach (var dto in exchangeDTOs)
                {
                    var sellOrderResponses = _orderService.GetSellOrdersFromExchangeDTO(dto);
                    var fitOrdersInExchange = FindSellFitInExchange(requestInfo.BTCAmount, dto.BTCBalance, sellOrderResponses.Value);
                    orderResponses.AddRange(fitOrdersInExchange);
                }

                orderResponses = orderResponses.OrderByDescending(o => o.Price)
                    .ThenByDescending(o => o.Amount)
                    .ToList();
            }
            else if (requestInfo.OrderType == OrderTypeEnum.Buy)
            {
                foreach (var dto in exchangeDTOs)
                {
                    var buyOrderResponses = _orderService.GetBuyOrdersFromExchangeDTO(dto);
                    var fitOrdersInExchange = FindBuyFitInExchange(requestInfo.BTCAmount, dto.EuroBalance, buyOrderResponses.Value);
                    orderResponses.AddRange(fitOrdersInExchange);
                }

                orderResponses = orderResponses.OrderBy(o => o.Price)
                    .ThenByDescending(o => o.Amount)
                    .ToList();
            }
            else
            {
                return new ServiceResult("Unknown order type");
            }

            return FindFit(requestInfo.BTCAmount, orderResponses);
        }

        private ServiceObjectResult<List<GetOrderResponse>> FindFit(decimal BTCAmount, List<GetOrderResponse> orderResponses)
        {
            var fits = new List<GetOrderResponse>(orderResponses.Count);
            var currentAmount = 0M;

            foreach (var item in orderResponses)
            {
                if (item.Amount <= BTCAmount - currentAmount)
                {
                    fits.Add(item);
                }
                else if (BTCAmount - currentAmount > 0)
                {
                    item.Amount = BTCAmount - currentAmount;
                    fits.Add(item);
                }
                currentAmount += item.Amount;
            }

            if (fits.Count == 0)
            {
                var message = "No orders that fit your request were found";
                return new ServiceObjectResult<List<GetOrderResponse>>(message, fits);
            }

            return new ServiceObjectResult<List<GetOrderResponse>>(fits);
        }

        private string GetOrderBookFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Help\order_books_data");
        }

        private List<GetOrderResponse> FindBuyFitInExchange(decimal BTCAmount, decimal EURBalance, List<GetOrderResponse> orders)
        {
            var fits = new List<GetOrderResponse>(orders.Count);
            var currentAmount = 0M;

            foreach (var item in orders)
            {
                if (EURBalance > 0
                    && EURBalance / item.Price >= item.Amount
                    && BTCAmount - currentAmount >= item.Amount)
                {
                    fits.Add(item);
                    EURBalance -= item.Amount * item.Price;
                    currentAmount += item.Amount;
                }
                else if (EURBalance > 0)
                {
                    item.Amount = EURBalance / item.Price;
                    fits.Add(item);
                    EURBalance -= item.Amount * item.Price;
                    currentAmount -= item.Amount;
                }
            }

            return fits;
        }

        private List<GetOrderResponse> FindSellFitInExchange(decimal BTCAmount, decimal BTCBalance, List<GetOrderResponse> orders)
        {
            var fits = new List<GetOrderResponse>(orders.Count);
            var amount = BTCAmount > BTCBalance ? BTCBalance : BTCAmount;

            foreach (var item in orders)
            {
                if (amount >= item.Amount)
                {
                    fits.Add(item);
                }
                else if (amount > 0)
                {
                    item.Amount = amount;
                    fits.Add(item);
                }
                amount -= item.Amount;
            }

            return fits;
        }
    }
}
