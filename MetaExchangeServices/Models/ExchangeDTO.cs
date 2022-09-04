namespace MetaExchange.Services.Models
{
    public class ExchangeDTO
    {
        public string ID { get; set; }
        public decimal BTCBalance { get; set; }
        public decimal EuroBalance { get; set; }
        public OrderBookDTO OrderBook { get; set; }
    }
}