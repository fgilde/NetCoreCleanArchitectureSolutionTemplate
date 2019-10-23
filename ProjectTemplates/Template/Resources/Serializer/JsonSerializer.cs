using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using $ext_safeprojectname$.Application.Contracts;

namespace $safeprojectname$.Serializer
{
    internal class JsonSerializer : IJsonSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            ContractResolver = new CustomContractResolver()
        };

        string IJsonSerializer.Serialize(object value) => JsonConvert.SerializeObject(value, settings);

        T IJsonSerializer.Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value, settings);


        private class CustomContractResolver : DefaultContractResolver
        {
            protected override List<MemberInfo> GetSerializableMembers(Type objectType)
            {
                return base.GetSerializableMembers(objectType)
                    .Where(m => m.CustomAttributes.All(attr => attr.AttributeType != typeof(SuppressAttribute)))
                    .ToList();
            }
        }
    }
}
