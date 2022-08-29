using MetaExchange.ConsoleUI;
using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services;
using MetaExchange.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetaExchange.ConsoleApp
{
    public class Service : IService
    {
        private readonly IInputDataService _inputDataService;
        private readonly IOrderBookService _orderBookService;
        private Dictionary<string, OrderBook> _orderDictionary;
        private RequestInfo _requestInfo = new RequestInfo();
        private IEnumerable<GetOrderResponse> _orders;

        public Service(IInputDataService inputDataService,
            IOrderBookService orderBookService)
        {
            _inputDataService = inputDataService;
            _orderBookService = orderBookService;
        }

        public async Task<bool> Go()
        {
            var result = await ProcessDataFilePath();
            ProcessOrderTypeInput();
            ProcessBTCAmountInput();
            ProcessBalanceInput(CurrencyTypeEnum.BTC);
            ProcessBalanceInput(CurrencyTypeEnum.EUR);

            RenderInputInfo();
            result = await FindBestFit(_requestInfo.OrderType);
            RenderOutputInfo();

            return result;
        }

        private async Task<bool> ProcessDataFilePath()
        {
            var flag = false;

            while (!flag)
            {
                Console.WriteLine("> Input the path of data file");
                var dataFilePath = Console.ReadLine().ToLower();
                try
                {
                    var result = await _inputDataService.ProcessOrderBooksDataFilePathAsync(dataFilePath);
                    if (result is ServiceObjectResult<Dictionary<string, OrderBook>>)
                    {
                        _orderDictionary = (result as ServiceObjectResult<Dictionary<string, OrderBook>>).Value;
                        flag = true;
                    }
                    else
                    {
                        throw new Exception(result.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return flag;
        }

        private void ProcessOrderTypeInput()
        {
            var flag = false;

            while (!flag)
            {
                Console.WriteLine("> Input the order type: B - for buy or S - for sell");
                var input = Console.ReadLine();

                if (input.ToLower() == "b")
                {
                    _requestInfo.OrderType = OrderTypeEnum.Buy;
                    flag = true;
                }
                else if (input.ToLower() == "s")
                {
                    _requestInfo.OrderType = OrderTypeEnum.Sell;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("> Unknown command");
                }
            }
        }

        private void ProcessBTCAmountInput()
        {
            var flag = false;

            while (!flag)
            {
                Console.WriteLine($"> Input the amount of BTS to {_requestInfo.OrderType.ToString().ToLower()}");
                var BTSAmount = Console.ReadLine().ToLower();

                try
                {
                    var result = _inputDataService.ProcessCurrencyAmount(BTSAmount);

                    if (result is ServiceObjectResult<double>)
                    {
                        _requestInfo.BTCAmount = (result as ServiceObjectResult<double>).Value;
                        flag = true;
                    }
                    else
                    {
                        throw new Exception(result.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessBalanceInput(CurrencyTypeEnum currencyType)
        {
            var flag = false;

            while (!flag)
            {
                Console.WriteLine($"> Input your {currencyType} balance");
                var balance = Console.ReadLine().ToLower();

                try
                {
                    var result = _inputDataService.ProcessCurrencyAmount(balance);
                    var isOfDouble = result is ServiceObjectResult<double>;

                    if (isOfDouble && currencyType == CurrencyTypeEnum.EUR)
                    {
                        _requestInfo.EuroBalance = (result as ServiceObjectResult<double>).Value;
                        flag = true;
                    }
                    else if (isOfDouble && currencyType == CurrencyTypeEnum.BTC)
                    {
                        _requestInfo.BTCBalance = (result as ServiceObjectResult<double>).Value;
                        flag = true;
                    }
                    else
                    {
                        throw new Exception(result.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void RenderInputInfo()
        {
            Console.WriteLine(new string('_', 25));
            Console.WriteLine($"OrderType: {_requestInfo.OrderType};\nBTC amount: {_requestInfo.BTCAmount};" +
                $"\nBTC current balance: {_requestInfo.BTCBalance};\nEuro current balance: {_requestInfo.EuroBalance}");
            Console.WriteLine(new string('_', 25));
            Console.WriteLine("Processing your request...");
        }

        private async Task<bool> FindBestFit(OrderTypeEnum orderType)
        {
            try
            {
                var serviceObjectResult =  await _orderBookService.FindBestFit(_requestInfo, _orderDictionary);
                _orders = serviceObjectResult.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return true;
        }

        private void RenderOutputInfo()
        {
            if ((_orders as List<GetOrderResponse>).Count > 0)
            {
                foreach (var item in _orders)
                {
                    Console.WriteLine($"OrderBookId: {item.OrderBookId}; Amount: {item.Amount}; Price: {item.Price}");
                }
            }
            else
            {
                Console.WriteLine("No orders that fit your request were found");
            }
        }
    }
}

