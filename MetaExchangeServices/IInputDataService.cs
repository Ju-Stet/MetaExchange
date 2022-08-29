using MetaExchange.Models;
using System.Threading.Tasks;

namespace MetaExchange.Services
{
    public interface IInputDataService
    {
        Task<ServiceResult> ProcessOrderBooksDataFilePathAsync(string input);
        ServiceResult ProcessCurrencyAmount(string currencyAmount);
    }
}
