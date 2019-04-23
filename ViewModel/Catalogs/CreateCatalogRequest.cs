using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Catalogs
{
    public class CreateCatalogRequest
    {
        [Required]
        [Display(Name = "Наименование справочника")]
        public string Name { get; set; }

        [Display(Name = "Описание справочника")]
        public string Text { get; set; }

        [Display(Name = "Тип справочника")]
        public string Type { get; set; }


        [Display(Name = "Родительский каталог справочника")]
        public Guid? ParentId { get; set; }
    }
}
