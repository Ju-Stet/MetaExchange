using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MetaExchange.Services
{
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderService _orderService;
        private readonly IInputDataService _inputDataService;
        public OrderBookService(IOrderService orderService,
            IInputDataService inputDataService)
        {
            _orderService = orderService;
            _inputDataService = inputDataService;
        }

        public ServiceObjectResult<List<GetOrderResponse>> FindBestFit(RequestInfo requestInfo,
            List<IdOrderBookDTO> idOrderBookDTOs = null)
        {
            if (idOrderBookDTOs == null)
            {
                string path = GetOrderBookFilePath();
                var serviceResult = _inputDataService.ProcessOrderBooksDataFilePath(path) as ServiceObjectResult<List<IdOrderBookDTO>>;
                idOrderBookDTOs = serviceResult.Value;
            }

            return requestInfo.OrderType switch
            {
                OrderTypeEnum.Buy => FindBestBuyFit(requestInfo, idOrderBookDTOs),
                OrderTypeEnum.Sell => FindBestSellFit(requestInfo, idOrderBookDTOs),
                _ => new ServiceObjectResult<List<GetOrderResponse>>()
            };
        }

        private ServiceObjectResult<List<GetOrderResponse>> FindBestBuyFit(RequestInfo requestInfo,
            List<IdOrderBookDTO> idOrderBookDTOs)
        {
            var ord = _orderService.GetSellOrdersFromOrderBooks(idOrderBookDTOs);
            var orders = ord.Value;
            var balance = requestInfo.EuroBalance;
            var fits = new List<GetOrderResponse>(orders.Count);
            var currentAmount = 0M;

            foreach (var item in orders)
            {
                var itemCost = item.Amount * item.Price;

                if (item.Amount <= requestInfo.BTCAmount - currentAmount
                    && balance >= itemCost)
                {
                    fits.Add(item);
                    balance -= itemCost;
                    currentAmount += item.Amount;
                }
            }

            if (fits.Count == 0)
            {
                var message = "No orders that fit your request were found";
                return new ServiceObjectResult<List<GetOrderResponse>>(message, fits);
            }

            return new ServiceObjectResult<List<GetOrderResponse>>(fits);
        }

        private ServiceObjectResult<List<GetOrderResponse>> FindBestSellFit(RequestInfo requestInfo, List<IdOrderBookDTO> idOrderBookDTOs)
        {
            var orders = _orderService.GetBuyOrdersFromOrderBooks(idOrderBookDTOs).Value as List<GetOrderResponse>;
            var amount = requestInfo.BTCAmount > requestInfo.BTCBalance ? requestInfo.BTCBalance : requestInfo.BTCAmount;
            var count = orders.Count;
            var fits = new List<GetOrderResponse>(count);

            foreach (var item in orders)
            {
                if (amount >= item.Amount)
                {
                    fits.Add(item);
                    amount -= item.Amount;
                }
            }

            return new ServiceObjectResult<List<GetOrderResponse>>(fits);
        }

        private string GetOrderBookFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Help\order_books_data");
        }
    }
}
