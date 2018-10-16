using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string RoleDescription { get; set; }
    }
}
