using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Models;
using System;
using System.Collections.Generic;

namespace MetaExchange.Services.Tests
{
    internal class TestHelper
    {
        public static Dictionary<string, OrderBook> GetOrderBookDictionary()
        {
            var orderBookDictionary = new Dictionary<string, OrderBook>();

            orderBookDictionary.Add("1548759600.25189", new OrderBook
            {
                AcqTime = DateTime.Today,
                Bids = new Ask[]
                {
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.1,
                            Price = 2960.64
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.1,
                            Price = 2960.63
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.01226619,
                            Price = 2958.95
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.06,
                            Price = 2958.52
                        }
                    },
                },

                Asks = new Ask[]
                {
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.1,
                            Price = 2949.71
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.12,
                            Price = 2950.63
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.0226619,
                            Price = 2950.95
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.06,
                            Price = 2951.22
                        }
                    },
                }

            });

            orderBookDictionary.Add("1548759601.33694", new OrderBook
            {
                AcqTime = DateTime.Today,
                Bids = new Ask[]
                {
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.1,
                            Price = 2960.65
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.1,
                            Price = 2960.63
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.01226619,
                            Price = 2958.75
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.06,
                            Price = 2958.52
                        }
                    },
                },

                Asks = new Ask[]
                {
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.11,
                            Price = 2949.71
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.12,
                            Price = 2950.53
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.0226619,
                            Price = 2950.95
                        }
                    },
                    new Ask()
                    {
                        Order = new Order()
                        {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Sell,
                            Kind = KindEnum.Limit,
                            Amount = 0.06,
                            Price = 2951.52
                        }
                    },
                }

            });

            return orderBookDictionary;
        }

        public static IEnumerable<GetOrderResponse> GetSellOrders()
        {
            var orderedSellOrders = new List<GetOrderResponse>();

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.1,
                Price = 2949.71
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12,
                Price = 2950.63
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619,
                Price = 2950.95
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06,
                Price = 2951.22
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.11,
                Price = 2949.71
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12,
                Price = 2950.53
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619,
                Price = 2950.95
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06,
                Price = 2951.52
            });

            return orderedSellOrders;
        }

        public static IEnumerable<GetOrderResponse> GetBuyOrders()
        {
            var orderedBuyOrders = new List<GetOrderResponse>();

            orderedBuyOrders.Add(
                  new GetOrderResponse()
                  {
                      OrderBookId = "1548759600.25189",
                      Id = null,
                      Time = DateTime.Today,
                      Type = OrderTypeEnum.Buy,
                      Kind = KindEnum.Limit,
                      Amount = 0.1,
                      Price = 2960.64
                  });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.63
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619,
                    Price = 2958.95
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06,
                    Price = 2958.52
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.65
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.63
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619,
                    Price = 2958.75
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06,
                    Price = 2958.52
                });

            return orderedBuyOrders;
        }

        public static IEnumerable<GetOrderResponse> GetOrderedSellOrders()
        {
            var orderedSellOrders = new List<GetOrderResponse>();

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.11,
                Price = 2949.71
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.1,
                Price = 2949.71
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12,
                Price = 2950.53
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12,
                Price = 2950.63
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619,
                Price = 2950.95
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619,
                Price = 2950.95
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06,
                Price = 2951.22
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06,
                Price = 2951.52
            });

            return orderedSellOrders;
        }

        public static IEnumerable<GetOrderResponse> GetOrderedBuyOrders()
        {
            var orderedBuyOrders = new List<GetOrderResponse>();

            orderedBuyOrders.Add(
                  new GetOrderResponse()
                  {
                      OrderBookId = "1548759601.33694",
                      Id = null,
                      Time = DateTime.Today,
                      Type = OrderTypeEnum.Buy,
                      Kind = KindEnum.Limit,
                      Amount = 0.1,
                      Price = 2960.65
                  });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.64
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.63
                });
            
            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.63
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619,
                    Price = 2958.95
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619,
                    Price = 2958.75
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06,
                    Price = 2958.52
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06,
                    Price = 2958.52
                });

            return orderedBuyOrders;
        }

        public static IEnumerable<GetOrderResponse> GetFitForBuyRequest()
        {
            var fitForBuy = new List<GetOrderResponse>();

            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.11,
                Price = 2949.71
            });

            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.1,
                Price = 2949.71
            });
            

            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619,
                Price = 2950.95
            });

            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619,
                Price = 2950.95
            });            

            return fitForBuy;
        }

        public static IEnumerable<GetOrderResponse> GetFitForSellRequest()
        {
            var fitForSell = new List<GetOrderResponse>();

            fitForSell.Add(
                  new GetOrderResponse()
                  {
                      OrderBookId = "1548759601.33694",
                      Id = null,
                      Time = DateTime.Today,
                      Type = OrderTypeEnum.Buy,
                      Kind = KindEnum.Limit,
                      Amount = 0.1,
                      Price = 2960.65
                  });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.64
                });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1,
                    Price = 2960.63
                });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619,
                    Price = 2958.95
                });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619,
                    Price = 2958.75
                });

            return fitForSell;
        }

    }
}
