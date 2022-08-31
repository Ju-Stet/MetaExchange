using MetaExchange.Models.Enums;

namespace MetaExchange.Services.Models
{
    public class RequestInfo
    {
        public OrderTypeEnum OrderType { get; set; }
        public decimal BTCAmount { get; set; }
        public decimal BTCBalance { get; set; }
        public decimal EuroBalance { get; set; }
    }
}
