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
        private double currentAmount = 0D;
        public OrderBookService(IOrderService orderService,
            IInputDataService inputDataService)
        {
            _orderService = orderService;
            _inputDataService = inputDataService;
        }

        public ServiceObjectResult<IEnumerable<GetOrderResponse>> FindBestFit(RequestInfo requestInfo,
            Dictionary<string, OrderBook> orderBookDictionary = null)
        {
            if (orderBookDictionary == null)
            {
                string path = GetOrderBookFilePath();
                var serviceResult = _inputDataService.ProcessOrderBooksDataFilePath(path) as ServiceObjectResult<Dictionary<string, OrderBook>>;
                orderBookDictionary = serviceResult.Value;
            }

            return requestInfo.OrderType switch
            {
                OrderTypeEnum.Buy => FindBestBuyFit(requestInfo, orderBookDictionary),
                OrderTypeEnum.Sell => FindBestSellFit(requestInfo, orderBookDictionary),
                _ => new ServiceObjectResult<IEnumerable<GetOrderResponse>>()
            };
        }

        private ServiceObjectResult<IEnumerable<GetOrderResponse>> FindBestBuyFit(RequestInfo requestInfo,
            Dictionary<string, OrderBook> orderBookDictionary)
        {
            var ord = _orderService.GetSellOrdersFromOrderBooks(orderBookDictionary);
            var orders = ord.Value as List<GetOrderResponse>;
            var balance = requestInfo.EuroBalance;
            var fits = new List<GetOrderResponse>(orders.Count);

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
                return new ServiceObjectResult<IEnumerable<GetOrderResponse>>(message, fits);
            }

            return new ServiceObjectResult<IEnumerable<GetOrderResponse>>(fits);
        }

        private ServiceObjectResult<IEnumerable<GetOrderResponse>> FindBestSellFit(RequestInfo requestInfo, Dictionary<string, OrderBook> orderBookDictionary)
        {
            var orders = _orderService.GetBuyOrdersFromOrderBooks(orderBookDictionary).Value as List<GetOrderResponse>;
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

            return new ServiceObjectResult<IEnumerable<GetOrderResponse>>(fits);
        }

        private string GetOrderBookFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Help\order_books_data");
        }
    }
}
