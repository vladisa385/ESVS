using System;

namespace DataAccess.Users
{
    public class IncorrectPasswordOrEmailExeption : Exception

    {
        public IncorrectPasswordOrEmailExeption() : base("Password or email are incorrect ")
        {

        }
    }
}
