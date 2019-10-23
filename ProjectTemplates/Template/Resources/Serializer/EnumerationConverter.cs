using System;
using System.Reflection;
using Newtonsoft.Json;

namespace $safeprojectname$.Serializer
{
    internal class EnumerationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //var type = objectType.BaseType;
            //while (type != null)
            //{
            //    if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Enumeration<>)))
            //        return true;
            //    type = type.BaseType;
            //}

            return false;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            int value = serializer.Deserialize<int>(reader);
            var methodInfo = objectType.GetMethod("GetById", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            return methodInfo.Invoke(null, new object[] { value });
        }
    }
}