using System;

namespace MetaExchange.Services.Models
{
    public class OrderBookDTO
    {
        public DateTimeOffset AcqTime { get; set; }

        public AskDTO[] Bids { get; set; }

        public AskDTO[] Asks { get; set; }
    }
}
