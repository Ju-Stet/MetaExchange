using MetaExchange.Models.Enums;
using Newtonsoft.Json;
using System;

namespace MetaExchange.Services.Converters
{
    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) 
            => t == typeof(OrderTypeEnum) || t == typeof(OrderTypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            { 
                return null; 
            }

            var value = serializer.Deserialize<string>(reader);

            if (value == OrderTypeEnum.Buy.ToString())
            {
                return OrderTypeEnum.Buy;
            }
            else if (value == OrderTypeEnum.Sell.ToString())
            {
                return OrderTypeEnum.Sell;
            }

            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OrderTypeEnum)untypedValue;

            if (value == OrderTypeEnum.Buy)
            {
                serializer.Serialize(writer, "Buy");
                return;
            }
            else if (value == OrderTypeEnum.Sell)
            {
                serializer.Serialize(writer, "Sell");
                return;
            }

            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
