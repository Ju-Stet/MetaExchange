using System.Threading.Tasks;

namespace MetaExchange.ConsoleUI
{
    public interface IService
    {
        public Task<bool> Go();
    }
}
