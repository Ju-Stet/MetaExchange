using MetaExchange.Models.Enums;
using System;

namespace MetaExchange.Models
{
    public class Order
    {
        public object Id { get; set; }

        public DateTimeOffset Time { get; set; }

        public OrderTypeEnum Type { get; set; }

        public KindEnum Kind { get; set; }

        public decimal Amount { get; set; }

        public decimal Price { get; set; }
    }
}
