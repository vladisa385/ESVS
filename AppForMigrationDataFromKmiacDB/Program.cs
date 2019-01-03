using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using ViewModel.Kmiac;

namespace AppForMigrationDataFromKmiacDB
{
    class Program
    {
        private static string _baseFolderUrl = "https://esvs.kmiac.ru/dataTree?_dc=1&node=";
        private static string _baseFieldUrl = "https://esvs.kmiac.ru/esvs/table/";
        public static List<Catalog> _catalogs = new List<Catalog>();
        public static List<Field> _fields = new List<Field>();
        private static async Task Main(string[] args)
        {
            var parser = new Parser();
            var folders = parser.GetCatalogs(_baseFolderUrl + "root");
            var collection = folders.ToList();
            GenerateFolders(parser, collection);
            _catalogs.AddRange(collection);
            var selectedCatalogs = _catalogs.Where(x => x.Name != null && x.Type != "folder").Select(x =>
               {
                   x.Id = x.Guid;
                   x.ParentId = x.ParentGuid;
                   return x;
               }).ToList();
            foreach (var catalog in selectedCatalogs)
            {
                var fields = parser.GetFields(_baseFieldUrl + catalog.Name);
                fields = fields.Select(x =>
                {
                    x.Id = Guid.NewGuid();
                    x.Catalog = catalog;
                    x.CatalogId = catalog.Guid;
                    x.IsForeignKey = x.Name.Contains("ID");
                    return x;

                }).ToList();
                _fields.AddRange(fields);

            }
            Console.WriteLine(_fields.Count);
            Console.WriteLine(_catalogs.Count);
            Console.ReadKey();
        }

        private static void GenerateFolders(Parser parser, IEnumerable<Catalog> catalogs)
        {
            foreach (var catalog in catalogs)
            {
                var newUrl = _baseFolderUrl +
                             catalog.Guid.ToString().Replace("-", "").ToUpper();

                var childCatalogs = parser.GetCatalogs(newUrl);
                var generateFolders = childCatalogs.ToList();
                _catalogs.AddRange(generateFolders);

                foreach (var childCatalog in generateFolders)
                {
                    GenerateFolders(parser,
                        parser.GetCatalogs(_baseFolderUrl + childCatalog.Guid));
                }

            }
        }


    }
}
