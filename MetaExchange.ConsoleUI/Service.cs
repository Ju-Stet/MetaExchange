using MetaExchange.ConsoleUI;
using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services;
using MetaExchange.Services.Models;
using System;
using System.Collections.Generic;

namespace MetaExchange.ConsoleApp
{
    public class Service : IService
    {
        private readonly IInputDataService _inputDataService;
        private readonly IOrderBookService _orderBookService;
        private List<IdOrderBookDTO> _idOrderBookDTOs;
        private RequestInfo _requestInfo = new RequestInfo();
        private List<GetOrderResponse> _orders;

        public Service(IInputDataService inputDataService,
            IOrderBookService orderBookService)
        {
            _inputDataService = inputDataService;
            _orderBookService = orderBookService;
        }

        public void Go(string[] args)
        {
            ProcessBalanceInput(CurrencyTypeEnum.EUR, args[0]);
            ProcessBalanceInput(CurrencyTypeEnum.BTC, args[1]);
            ProcessDataFilePath(args[2]);
            ProcessOrderTypeInput(args[3]);
            ProcessBTCAmountInput(args[4]);

            RenderInputInfo();
            FindBestFit(_requestInfo.OrderType);
            RenderOutputInfo();
        }



        private void ProcessDataFilePath(string path)
        {
            var result = _inputDataService.ProcessOrderBooksDataFilePath(path);
            if (result is ServiceObjectResult<List<IdOrderBookDTO>>)
            {
                _idOrderBookDTOs = (result as ServiceObjectResult<List<IdOrderBookDTO>>).Value;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        private void ProcessOrderTypeInput(string orderType)
        {
            if (orderType.ToLower() == OrderTypeEnum.Buy.ToString().ToLower())
            {
                _requestInfo.OrderType = OrderTypeEnum.Buy;

            }
            else if (orderType.ToLower() == OrderTypeEnum.Sell.ToString().ToLower())
            {
                _requestInfo.OrderType = OrderTypeEnum.Sell;
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private void ProcessBTCAmountInput(string BTCAmount)
        {
            try
            {
                var result = _inputDataService.ProcessCurrencyAmount(BTCAmount);

                if (result is ServiceObjectResult<decimal>)
                {
                    _requestInfo.BTCAmount = (result as ServiceObjectResult<decimal>).Value;
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

        private void ProcessBalanceInput(CurrencyTypeEnum currencyType, string balance)
        {
            try
            {
                var result = _inputDataService.ProcessCurrencyAmount(balance);
                var isOfDouble = result is ServiceObjectResult<decimal>;

                if (isOfDouble && currencyType == CurrencyTypeEnum.EUR)
                {
                    _requestInfo.EuroBalance = (result as ServiceObjectResult<decimal>).Value;
                }
                else if (isOfDouble && currencyType == CurrencyTypeEnum.BTC)
                {
                    _requestInfo.BTCBalance = (result as ServiceObjectResult<decimal>).Value;
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

        private void RenderInputInfo()
        {
            Console.WriteLine($"OrderType: {_requestInfo.OrderType};" +
                $"\nBTC amount: {_requestInfo.BTCAmount};" +
                $"\nBTC current balance: {_requestInfo.BTCBalance};" +
                $"\nEuro current balance: {_requestInfo.EuroBalance}.");
            Console.WriteLine(new string('_', 25));
            Console.WriteLine("Processing your request...");
            Console.WriteLine(new string('_', 25));
        }

        private void FindBestFit(OrderTypeEnum orderType)
        {
            try
            {
                var serviceObjectResult = _orderBookService.FindBestFit(_requestInfo, _idOrderBookDTOs);
                _orders = serviceObjectResult.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RenderOutputInfo()
        {
            if (_orders.Count > 0)
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

