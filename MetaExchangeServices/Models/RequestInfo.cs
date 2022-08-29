using MetaExchange.Models.Enums;

namespace MetaExchange.Services.Models
{
    public class RequestInfo
    {
        public OrderTypeEnum OrderType { get; set; }
        public double BTCAmount { get; set; }
        public double BTCBalance { get; set; }
        public double EuroBalance { get; set; }
    }
}
