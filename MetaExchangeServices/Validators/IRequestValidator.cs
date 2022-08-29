using MetaExchange.Models;
using MetaExchange.Services.Models;

namespace MetaExchange.Services.Validators
{
    public interface IRequestValidator
    {
        ServiceResult Validate(RequestInfo requestInfo);
    }
}