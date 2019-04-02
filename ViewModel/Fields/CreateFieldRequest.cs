using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Fields
{
    public class CreateFieldRequest
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Заголовок")]
        public string Caption { get; set; }
        [Required]
        [Display(Name = "Длина")]
        public int Length { get; set; }
        [Required]
        [Display(Name = "Является ли не пустым")]
        public bool NotNull { get; set; }
        [Required]
        [Display(Name = "Является ли внешним ключем")]
        public bool IsForeignKey { get; set; }
        [Required]
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "ID каталога")]
        public Guid CatalogId { get; set; }
    }
}
