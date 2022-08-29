The solution contains a console application and a web api application

When working with the console, you need to input the path to the file with order books, and input data for processing: type of operation (buy/sell), amount of currency, balances.

Web application accepts in the body of the request an object containing information about the type of operation (0 - buy, 1 - sale), amount of currency, currency balances. For example:
{
    "OrderType": 0,
    "BTCAmount": 0.11,
    "BTCBalance": 1,
    "EuroBalance": 1000
}

The architecture is built in such a way that both (console and web) applications refer to the business logic layer, where input data is processed (parsing, deserialization, data mapping to a common model and so on). The data model classes are in the layer represented by a separate project.
