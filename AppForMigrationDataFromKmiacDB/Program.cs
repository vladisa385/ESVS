using System;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppForMigrationDataFromKmiacDB
{
    class Program
    {
        private static string _folderUrl = "https://esvs.kmiac.ru/dataTree?_dc=1546508672232&node=root";

        private static async Task Main(string[] args)
        {
            var parser = new Parser();
            var folders = await parser.GetEntities<Folder>(_folderUrl,
                x => JsonConvert.DeserializeObject<JObject>(x)["children"].ToString());
            Console.ReadKey();
        }


    }
}
