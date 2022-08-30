using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public class OrderMapper : IOrderMapper
    {
        public List<GetOrderResponse> MapBuyOrderList(List<IdOrderBookDTO> idOrderBookDTOs)
        {
            var allOrderBooksOrderResponseList = new List<GetOrderResponse>();

            foreach (var entry in idOrderBookDTOs)
            {
                var orderResponseList = new List<GetOrderResponse>(entry.OrderBook.Bids.Length);

                foreach (var ask in entry.OrderBook.Bids)
                {
                    var orderResponse = MapOrder(ask, entry.ID);
                    orderResponseList.Add(orderResponse);
                }

                allOrderBooksOrderResponseList.AddRange(orderResponseList);
            }

            return allOrderBooksOrderResponseList;
        }

        public List<GetOrderResponse> MapSellOrderList(List<IdOrderBookDTO> idOrderBookDTOs)
        {
            var allOrderBooksOrderResponseList = new List<GetOrderResponse>();

            foreach (var entry in idOrderBookDTOs)
            {
                var orderResponseList = new List<GetOrderResponse>(entry.OrderBook.Asks.Length);

                foreach (var ask in entry.OrderBook.Asks)
                {
                    var orderResponse = MapOrder(ask, entry.ID);
                    orderResponseList.Add(orderResponse);
                }

                allOrderBooksOrderResponseList.AddRange(orderResponseList);
            }

            return allOrderBooksOrderResponseList;
        }

        private GetOrderResponse MapOrder(AskDTO ask, string orderBookId)
        {
            GetOrderResponse orderResponse = new GetOrderResponse();

            orderResponse.OrderBookId = orderBookId;
            orderResponse.Id = ask.Order.Id;
            orderResponse.Time = ask.Order.Time;
            orderResponse.Type = ask.Order.Type;
            orderResponse.Kind = ask.Order.Kind;
            orderResponse.Amount = ask.Order.Amount;
            orderResponse.Price = ask.Order.Price;

            return orderResponse;
        }
    }
}
