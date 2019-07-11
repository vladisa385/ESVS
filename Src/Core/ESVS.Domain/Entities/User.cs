using System;
using Microsoft.AspNetCore.Identity;

namespace ESVS.Domain.Entities
{
    public class User : IdentityUser<Guid>

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }

    }
}
