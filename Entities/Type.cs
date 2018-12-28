using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Type
    {
        [Required]
        public Guid Id { get; set; }
        [MinLength(5), MaxLength(40)]
        public string Name { get; set; }
    }
}
