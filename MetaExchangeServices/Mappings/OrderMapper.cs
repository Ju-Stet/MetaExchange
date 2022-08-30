using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public class OrderMapper : IOrderMapper
    {
        public List<GetOrderResponse> MapBuyOrderList(Dictionary<string, OrderBook> orderBookDictionary)
        {
            var allOrderBooksOrderResponseList = new List<GetOrderResponse>();

            foreach (KeyValuePair<string, OrderBook> entry in orderBookDictionary)
            {
                var orderResponseList = new List<GetOrderResponse>(entry.Value.Bids.Length);

                foreach (var ask in entry.Value.Bids)
                {
                    var orderResponse = MapOrder(ask, entry.Key);
                    orderResponseList.Add(orderResponse);
                }

                allOrderBooksOrderResponseList.AddRange(orderResponseList);
            }

            return allOrderBooksOrderResponseList;
        }

        public List<GetOrderResponse> MapSellOrderList(Dictionary<string, OrderBook> orderBookDictionary)
        {
            var allOrderBooksOrderResponseList = new List<GetOrderResponse>();

            foreach (KeyValuePair<string, OrderBook> entry in orderBookDictionary)
            {
                var orderResponseList = new List<GetOrderResponse>(entry.Value.Asks.Length);

                foreach (var ask in entry.Value.Asks)
                {
                    var orderResponse = MapOrder(ask, entry.Key);
                    orderResponseList.Add(orderResponse);
                }

                allOrderBooksOrderResponseList.AddRange(orderResponseList);
            }

            return allOrderBooksOrderResponseList;
        }

        private GetOrderResponse MapOrder(Ask ask, string key)
        {
            GetOrderResponse orderResponse = new GetOrderResponse();

            orderResponse.OrderBookId = key;
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
