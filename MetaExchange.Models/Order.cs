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

        public double Amount { get; set; }

        public double Price { get; set; }
    }
}
