using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.General;
using DB;
using KmiacParser;
using ViewModel.Kmiac;

namespace DataAccess.DbImplementation.General
{
    public class GenerateDbFromKmiac : IGenerateDbFromKmiac
    {
        private readonly AppDbContext _context;
        private readonly Parser _parser;
        private readonly IMapper _mapper;
        private readonly string _baseFolderUrl = "https://esvs.kmiac.ru/dataTree?_dc=1&node=";
        private readonly string _baseFieldUrl = "https://esvs.kmiac.ru/esvs/table/";
        private List<ViewModel.Kmiac.Catalog> _catalogs = new List<ViewModel.Kmiac.Catalog>();
        private readonly List<ViewModel.Kmiac.Field> _fields = new List<ViewModel.Kmiac.Field>();
        public GenerateDbFromKmiac(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _parser = new Parser();
        }

        public async Task ExecuteAsync()
        {
            GenerateCatalogs();
            GenerateFields();
            _context.Catalogs.RemoveRange(_context.Catalogs);
            _context.Fields.RemoveRange(_context.Fields);
            var dbCatalogs =
                _catalogs.Select(u => _mapper.Map<ViewModel.Kmiac.Catalog, Entities.Catalog>(u)).OrderBy(u => u.ParentId != null).ToList();
            var dbFields =
                _fields.Select(u => _mapper.Map<ViewModel.Kmiac.Field, Entities.Field>(u)).ToList();
            await _context.Catalogs.AddRangeAsync(dbCatalogs);
            await _context.Fields.AddRangeAsync(dbFields);
            await _context.SaveChangesAsync();
        }

        private void GenerateFolders(Parser parser, IEnumerable<ViewModel.Kmiac.Catalog> catalogs)
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

        private void GenerateCatalogs()
        {

            var folders = _parser.GetCatalogs(_baseFolderUrl + "root");
            var collection = folders.ToList();
            GenerateFolders(_parser, collection);

            _catalogs.AddRange(collection);
            _catalogs = _catalogs.Select(x =>
            {
                x.Id = x.Guid;
                x.ParentId = x.ParentGuid;
                return x;
            }).ToList();
        }

        private void GenerateFields()
        {
            var selectedCatalogs = _catalogs.Where(x => x.Name != null && x.Type != "folder").ToList();
            foreach (var catalog in selectedCatalogs)
            {
                try
                {
                    var fields = _parser.GetFields(_baseFieldUrl + catalog.Name);
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
                catch (NullReferenceException)
                {
                }

            }
        }


    }
}
