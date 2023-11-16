using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class RetornoApi
    {

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]

        public string Status { get; set; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]

        public Object Data { get; set; }

        [JsonProperty(PropertyName = "token", NullValueHandling = NullValueHandling.Ignore)]

        public string Token { get; set; }

        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]

        public string Message { get; set; }

        public static RetornoApi Sucesso(object data = null, string token = "")
        {
            return new RetornoApi()
            {
                Status = "success",
                Data = data,
                Token = token
            };
        }

        public static RetornoApi Erro(string message)
        {
            return new RetornoApi()
            {
                Status = "error",
                Message = message
            };
        }
    }
}
