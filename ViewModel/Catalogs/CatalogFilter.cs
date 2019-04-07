using System;

namespace ViewModel.Catalogs
{
    public class CatalogFilter
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public Guid? ParentId { get; set; }

        public RangeFilter<int> ChildCatalogs { get; set; }

        public RangeFilter<int> Fields { get; set; }
    }
}
