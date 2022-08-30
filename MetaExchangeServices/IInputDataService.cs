using MetaExchange.Models;

namespace MetaExchange.Services
{
    public interface IInputDataService
    {
        ServiceResult ProcessOrderBooksDataFilePath(string input);
        ServiceResult ProcessCurrencyAmount(string currencyAmount);
    }
}
