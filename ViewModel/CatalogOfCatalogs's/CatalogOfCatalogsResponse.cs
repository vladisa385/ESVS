using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CatalogOfCatalogsResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CatalogOfCatalogsDescription { get; set; }
    }
}
