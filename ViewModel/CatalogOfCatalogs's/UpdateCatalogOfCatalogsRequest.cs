using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class UpdateCatalogOfCatalogsRequest
    {
        [Display(Name = "Имя")]
        [MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        [Display(Description = "Описание")]
        [MinLength(5), MaxLength(40)]
        public string CatalogOfCatalogsDescription { get; set; }
    }
}
