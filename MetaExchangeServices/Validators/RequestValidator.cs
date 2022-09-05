using MetaExchange.Models;
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

            return new ServiceResult() { IsSuccess = true };
        }
    }
}
