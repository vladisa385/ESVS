using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class Role : IdentityRole<Guid>
    {
        [MinLength(100), MaxLength(1000)]
        public string RoleDescription { get; set; }
    }
}
