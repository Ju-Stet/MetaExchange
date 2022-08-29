using System;

namespace MetaExchange.Models
{
    public class OrderBook
    {
        public int Id { get; set; }
        public DateTimeOffset AcqTime { get; set; }
        public Ask[] Bids { get; set; }
        public Ask[] Asks { get; set; }
    }

    public class Ask
    {
        public Order Order { get; set; }
    }
}
