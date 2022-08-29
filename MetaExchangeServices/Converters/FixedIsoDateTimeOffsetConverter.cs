using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace MetaExchange.Services.Converters
{
    public class FixedIsoDateTimeOffsetConverter : IsoDateTimeConverter
    {
        public override bool CanConvert(Type objectType)
            =>  objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        

        public FixedIsoDateTimeOffsetConverter() : base()
        {
            this.DateTimeStyles = DateTimeStyles.AssumeUniversal;
        }
    }
}
