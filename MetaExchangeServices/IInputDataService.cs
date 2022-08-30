using MetaExchange.Models;
using System.Threading.Tasks;

namespace MetaExchange.Services
{
    public interface IInputDataService
    {
        ServiceResult ProcessOrderBooksDataFilePath(string input);
        ServiceResult ProcessCurrencyAmount(string currencyAmount);
    }
}
