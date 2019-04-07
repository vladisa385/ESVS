using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ViewModel.Fields;
using ViewModel.Kmiac;

namespace ViewModel.Catalogs
{
    public class CatalogResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid? ParentId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int ChildCatalogsCount { get; set; }
        [Required]
        public ICollection<FieldResponse> Fields { get; set; }
        [Required]
        public ICollection<CatalogResponse> ChildCatalogs { get; set; }
        [Required]
        public int FieldsCount { get; set; }
    }
}
