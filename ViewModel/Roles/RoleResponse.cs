using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Roles
{
    public class RoleResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RoleDescription { get; set; }
    }
}
