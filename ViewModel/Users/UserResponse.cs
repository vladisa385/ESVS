using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Users
{
    public class UserResponse
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }
        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }
        public string PathToAvatar { get; set; }
        public Guid? LevelId { get; set; }
        [Required]

        public bool Gender { get; set; }
      

    }
}
