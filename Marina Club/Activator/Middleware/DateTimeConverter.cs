using Infrastructure.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Activator.Middleware
{
    public class DateTimeConverter : DateTimeExtensionBase
    {
        public virtual void WriteDateJson(JsonWriter writer , object value,JsonSerializer serializer)
        {
            writer.WriteValue(ConvertToShamsi((DateTime)value));

        }
        public virtual object ReadJson(JsonReader reader, Type objectType,object existingValue, JsonSerializer serializer)
        {
            try
            {
                return reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString())
                    ? (object)null
                    : ConvertToMiladiDate((DateTime)reader.Value);
            }
            catch (Exception)
            {
                return reader.Value;
            }
        }
    }
}
