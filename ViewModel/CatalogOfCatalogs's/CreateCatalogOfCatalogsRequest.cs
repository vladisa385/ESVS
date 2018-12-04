using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CreateCatalogOfCatalogsRequest
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string CatalogOfCatalogsDescription { get; set; }
    }
}
