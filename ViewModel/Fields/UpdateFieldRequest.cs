using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Fields
{
    public class UpdateFieldRequest
    {
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Заголовок")]
        public string Caption { get; set; }
        [Display(Name = "Длина")]
        public int Length { get; set; }
        [Display(Name = "Является ли не пустым")]
        public bool NotNull { get; set; }
        [Display(Name = "Является ли внешним ключем")]
        public bool IsForeignKey { get; set; }
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Display(Name = "ID каталога")]
        public Guid CatalogId { get; set; }
    }
}
