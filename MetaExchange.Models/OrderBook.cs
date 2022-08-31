using System;

namespace MetaExchange.Models
{
    public class OrderBook
    {
        public int Id { get; set; }
        public DateTimeOffset AcqTime { get; set; }
        public Order[] Bids { get; set; }
        public Order[] Asks { get; set; }
    }
}
