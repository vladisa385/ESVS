using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : IdentityUser<Guid>

    {
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }
        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public Guid? LevelId { get; set; }
        public bool Gender { get; set; }


    }
}
