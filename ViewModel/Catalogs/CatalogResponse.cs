using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CatalogsResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CatalogsDescription { get; set; }

        public int CatalogsCount { get; set; }
    }
}
