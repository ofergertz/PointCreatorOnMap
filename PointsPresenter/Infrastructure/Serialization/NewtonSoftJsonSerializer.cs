using Microsoft.Extensions.Options;
using Model.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Serialization
{
    public class NewtonSoftJsonSerializer : IJsonSerializer
    {

        public NewtonSoftJsonSerializer()
        {
        }

        public T Deserialize<T>(string text)
            => JsonConvert.DeserializeObject<T>(text);

        public string Serialize<T>(T obj)
            => JsonConvert.SerializeObject(obj);
    }
}
