using System;

namespace ViewModel.Users
{
    public class UserFilter
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string AboutYourself { get; set; }
    }
}
