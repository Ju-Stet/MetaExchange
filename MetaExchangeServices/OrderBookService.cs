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

        public ServiceResult FindBestFit(RequestInfo requestInfo,
            List<IdOrderBookDTO> idOrderBookDTOs = null)
        {
            if (idOrderBookDTOs == null)
            {
                string path = GetOrderBookFilePath();
                var serviceResult = _inputDataService.ProcessOrderBooksDataFilePath(path) as ServiceObjectResult<List<IdOrderBookDTO>>;
                idOrderBookDTOs = serviceResult.Value;
            }

            if (requestInfo.OrderType == OrderTypeEnum.Buy)
            {
                var orderResponses = _orderService.GetSellOrdersFromOrderBooks(idOrderBookDTOs);
                if (orderResponses != null)
                {
                    return FindBestBuyFit(requestInfo, orderResponses.Value);
                }
                return new ServiceResult("Could not get orders from order books");
            }
            else if (requestInfo.OrderType == OrderTypeEnum.Sell)
            {
                var orderResponses = _orderService.GetBuyOrdersFromOrderBooks(idOrderBookDTOs);
                if (orderResponses != null)
                {
                    return FindBestSellFit(requestInfo, orderResponses.Value);
                }
                return new ServiceResult("Could not get orders from order books");
            }

            return new ServiceResult("Unknown order type");
        }

        private ServiceObjectResult<List<GetOrderResponse>> FindBestBuyFit(RequestInfo requestInfo,
            List<GetOrderResponse> orderResponses)
        {
            var balance = requestInfo.EuroBalance;
            var fits = new List<GetOrderResponse>(orderResponses.Count);
            var currentAmount = 0M;

            foreach (var item in orderResponses)
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

        private ServiceObjectResult<List<GetOrderResponse>> FindBestSellFit(RequestInfo requestInfo, List<GetOrderResponse> orderResponses)
        {
            var amount = requestInfo.BTCAmount > requestInfo.BTCBalance ? requestInfo.BTCBalance : requestInfo.BTCAmount;
            var count = orderResponses.Count;
            var fits = new List<GetOrderResponse>(count);

            foreach (var item in orderResponses)
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
