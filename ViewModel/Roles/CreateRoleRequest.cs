using System.ComponentModel.DataAnnotations;

namespace ViewModel.Roles
{
    public class CreateRoleRequest
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string RoleDescription { get; set; }
    }
}
