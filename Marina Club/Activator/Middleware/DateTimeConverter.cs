using Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Marina_Club.Activator.Middleware
{
    public  class JsonDateTimeConvertor : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value,JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ConvertToShamsi());

        }
        public override object ReadJson(JsonReader reader, Type objectType,object existingValue, JsonSerializer serializer)
        {
            try
            {
                return reader.Value == null
                    ? (object)null
                    : reader.Value.ToString().ConvertToMiladiDate();
            }
            catch (Exception ex)
            {
                var errors = ex.Message;
                return reader.Value;
            }
        }
    }
}
