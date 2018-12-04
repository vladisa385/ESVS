using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModel.Users
{
    public class UpdateUserRequest
    {

        [Display(Name = "Имя")]
        [MinLength(5), MaxLength(40)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [MinLength(5), MaxLength(40)]
        public string LastName { get; set; }
        [Display(Name = "Пол")]
        public bool IsMen { get; set; }


        [Display(Name = "Аватар")]
        public IFormFile Avatar { get; set; }
    }
}
