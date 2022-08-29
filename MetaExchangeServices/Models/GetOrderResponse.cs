using MetaExchange.Models.Enums;
using System;

namespace MetaExchange.Services.Models
{
    public class GetOrderResponse
    {
        public string OrderBookId { get; set; }

        public object Id { get; set; }

        public DateTimeOffset Time { get; set; }

        public OrderTypeEnum Type { get; set; }

        public KindEnum Kind { get; set; }

        public double Amount { get; set; }

        public double Price { get; set; }
    }
}
