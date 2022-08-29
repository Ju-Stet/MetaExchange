using MetaExchange.Models.Enums;
using Newtonsoft.Json;
using System;

namespace MetaExchange.Services.Converters
{
    internal class KindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) 
            => t == typeof(KindEnum) || t == typeof(KindEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Limit")
            {
                return KindEnum.Limit;
            }
            throw new Exception("Cannot unmarshal type Kind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (KindEnum)untypedValue;
            if (value == KindEnum.Limit)
            {
                serializer.Serialize(writer, "Limit");
                return;
            }
            throw new Exception("Cannot marshal type Kind");
        }

        public static readonly KindConverter Singleton = new KindConverter();
    }
}
