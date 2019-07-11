
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ViewModel.Kmiac;

namespace KmiacParser
{
    public class Parser
    {
        private readonly HttpClient _client;

        public Parser() => 
            _client = new HttpClient();

        public ICollection<T> GetEntities<T>(string url, Func<string, string> filter)
        {
            var rawData = _client.GetStringAsync(url).Result;
            var resultData = filter.Invoke(rawData);
            return JsonConvert.DeserializeObject<ICollection<T>>(resultData);
        }

        public ICollection<Catalog> GetCatalogs(string url) =>
            GetEntities<Catalog>(url,
                x => JsonConvert.DeserializeObject<JObject>(x)["children"].ToString());

        public ICollection<Field> GetFields(string url) =>
            GetEntities<Field>(url,
                x => JsonConvert.DeserializeObject<JObject>(x)["fields"].ToString());
    }
}
