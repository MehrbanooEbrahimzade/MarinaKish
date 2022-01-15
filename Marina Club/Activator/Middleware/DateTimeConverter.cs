using Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Marina_Club.Activator.Middleware
{
    public  class JsonDateTimeConvertor : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer , object value,JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ConvertToShamsi());

        }
        public override object ReadJson(JsonReader reader, Type objectType,object existingValue, JsonSerializer serializer)
        {
            try
            {
                return reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString())
                    ? (object)null
                    : ((DateTime)reader.Value).ConvertToMiladiDate();
            }
            catch (Exception)
            {
                return reader.Value;
            }
        }
    }
}
