using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Models;
using System;
using System.Collections.Generic;

namespace MetaExchange.Services.Tests
{
    internal class TestHelper
    {
        public static List<IdOrderBookDTO> GetOrderBooks()
        {
            var orderBookDictionary = new List<IdOrderBookDTO>();

            orderBookDictionary.Add(new IdOrderBookDTO
            {
                ID = "1548759600.25189",
                OrderBook = new OrderBookDTO
                {
                    AcqTime = DateTime.Today,
                    Bids = new AskDTO[]
                    {
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.1M,
                                Price = 2960.64M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                            Id = null,
                            Time = DateTime.Today,
                            Type = OrderTypeEnum.Buy,
                            Kind = KindEnum.Limit,
                            Amount = 0.1M,
                            Price = 2960.63M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.01226619M,
                                Price = 2958.95M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.06M,
                                Price = 2958.52M
                            }
                        },
                    },

                    Asks = new AskDTO[]
                    {
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.1M,
                                Price = 2949.71M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.12M,
                                Price = 2950.63M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.0226619M,
                                Price = 2950.95M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.06M,
                                Price = 2951.22M
                            }
                        },
                    }
                }
            });

            orderBookDictionary.Add(new IdOrderBookDTO
            {
                ID = "1548759601.33694",
                OrderBook = new OrderBookDTO
                {
                    AcqTime = DateTime.Today,
                    Bids = new AskDTO[]
                    {
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.1M,
                                Price = 2960.65M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.1M,
                                Price = 2960.63M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.01226619M,
                                Price = 2958.75M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Buy,
                                Kind = KindEnum.Limit,
                                Amount = 0.06M,
                                Price = 2958.52M
                            }
                        },
                    },

                    Asks = new AskDTO[]
                    {
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.11M,
                                Price = 2949.71M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.12M,
                                Price = 2950.53M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.0226619M,
                                Price = 2950.95M
                            }
                        },
                        new AskDTO()
                        {
                            Order = new Order()
                            {
                                Id = null,
                                Time = DateTime.Today,
                                Type = OrderTypeEnum.Sell,
                                Kind = KindEnum.Limit,
                                Amount = 0.06M,
                                Price = 2951.52M
                            }
                        },
                    }
                }
            });

            return orderBookDictionary;
        }

        public static List<GetOrderResponse> GetSellOrders()
        {
            var orderedSellOrders = new List<GetOrderResponse>();

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.1M,
                Price = 2949.71M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12M,
                Price = 2950.63M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619M,
                Price = 2950.95M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06M,
                Price = 2951.22M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.11M,
                Price = 2949.71M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12M,
                Price = 2950.53M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619M,
                Price = 2950.95M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06M,
                Price = 2951.52M
            });

            return orderedSellOrders;
        }

        public static List<GetOrderResponse> GetBuyOrders()
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
                      Amount = 0.1M,
                      Price = 2960.64M
                  });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.63M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619M,
                    Price = 2958.95M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06M,
                    Price = 2958.52M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.65M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.63M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619M,
                    Price = 2958.75M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06M,
                    Price = 2958.52M
                });

            return orderedBuyOrders;
        }

        public static List<GetOrderResponse> GetOrderedSellOrders()
        {
            var orderedSellOrders = new List<GetOrderResponse>();

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.11M,
                Price = 2949.71M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.1M,
                Price = 2949.71M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12M,
                Price = 2950.53M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.12M,
                Price = 2950.63M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619M,
                Price = 2950.95M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619M,
                Price = 2950.95M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06M,
                Price = 2951.22M
            });

            orderedSellOrders.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.06M,
                Price = 2951.52M
            });

            return orderedSellOrders;
        }

        public static List<GetOrderResponse> GetOrderedBuyOrders()
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
                      Amount = 0.1M,
                      Price = 2960.65M
                  });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.64M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.63M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.63M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619M,
                    Price = 2958.95M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619M,
                    Price = 2958.75M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06M,
                    Price = 2958.52M
                });

            orderedBuyOrders.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.06M,
                    Price = 2958.52M
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
                Amount = 0.11M,
                Price = 2949.71M
            });

            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.1M,
                Price = 2949.71M
            });


            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759600.25189",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619M,
                Price = 2950.95M
            });

            fitForBuy.Add(new GetOrderResponse()
            {
                OrderBookId = "1548759601.33694",
                Id = null,
                Time = DateTime.Today,
                Type = OrderTypeEnum.Sell,
                Kind = KindEnum.Limit,
                Amount = 0.0226619M,
                Price = 2950.95M
            });

            return fitForBuy;
        }

        public static List<GetOrderResponse> GetFitForSellRequest()
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
                      Amount = 0.1M,
                      Price = 2960.65M
                  });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.64M
                });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.1M,
                    Price = 2960.63M
                });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759600.25189",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619M,
                    Price = 2958.95M
                });

            fitForSell.Add(
                new GetOrderResponse()
                {
                    OrderBookId = "1548759601.33694",
                    Id = null,
                    Time = DateTime.Today,
                    Type = OrderTypeEnum.Buy,
                    Kind = KindEnum.Limit,
                    Amount = 0.01226619M,
                    Price = 2958.75M
                });

            return fitForSell;
        }

    }
}
