
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppForMigrationDataFromKmiacDB
{
    public class Parser
    {
        private readonly HttpClient _client;

        public Parser()
        {
            _client = new HttpClient();

        }

        public async Task<ICollection<T>> GetEntities<T>(string url, Func<string, string> filter)
        {
            var rawData = await _client.GetStringAsync(url);
            var resultData = filter.Invoke(rawData);
            return JsonConvert.DeserializeObject<ICollection<T>>(resultData);
        }


    }
}
