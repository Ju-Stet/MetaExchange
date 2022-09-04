using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public class OrderMapper : IOrderMapper
    {
        public List<GetOrderResponse> MapBuyOrderList(ExchangeDTO exchangeDTO)
        {
            var orderResponseList = new List<GetOrderResponse>(exchangeDTO.OrderBook.Asks.Length);

            foreach (var ask in exchangeDTO.OrderBook.Asks)
            {
                var orderResponse = MapOrder(ask, exchangeDTO.ID);
                orderResponseList.Add(orderResponse);
            }

            return orderResponseList;
        }

        public List<GetOrderResponse> MapSellOrderList(ExchangeDTO exchangeDTO)
        {
            var orderResponseList = new List<GetOrderResponse>(exchangeDTO.OrderBook.Bids.Length);

            foreach (var bid in exchangeDTO.OrderBook.Bids)
            {
                var orderResponse = MapOrder(bid, exchangeDTO.ID);
                orderResponseList.Add(orderResponse);
            }

            return orderResponseList;
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
