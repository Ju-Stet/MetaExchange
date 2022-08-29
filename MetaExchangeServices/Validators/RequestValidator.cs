using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Models;

namespace MetaExchange.Services.Validators
{
    public class RequestValidator : IRequestValidator
    {
        public ServiceResult Validate(RequestInfo requestInfo)
        {
            if (requestInfo.EuroBalance < 0
                || requestInfo.BTCBalance < 0
                || requestInfo.BTCAmount < 0)
            {
                return new ServiceResult("Currency amount cannot be less than 0");
            }
            if (requestInfo.OrderType == OrderTypeEnum.Sell
                && requestInfo.BTCAmount > requestInfo.BTCBalance)
            {
                return new ServiceResult($"You cannot sell more than {requestInfo.BTCBalance} BTC.");
            }
            else if (requestInfo.OrderType == OrderTypeEnum.Buy
                && requestInfo.EuroBalance == 0)
            {
                return new ServiceResult("You cannot buy BTC due to low balance.");
            }
            return new ServiceResult() { IsSuccess = true };
        }
    }
}
