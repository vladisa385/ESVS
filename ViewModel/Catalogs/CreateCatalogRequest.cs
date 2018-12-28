using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CreateCatalogsRequest
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string CatalogsDescription { get; set; }
    }
}
