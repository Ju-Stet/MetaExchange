using Newtonsoft.Json;

namespace MetaExchange.Services.Converters
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                KindConverter.Singleton,
                TypeEnumConverter.Singleton,
                new FixedIsoDateTimeOffsetConverter()
            },
        };

    }
}
