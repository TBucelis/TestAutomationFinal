using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationFinal
{
    public class User
    {
        public static User TestUser = new User("laidokas@gmail.com", "testing123");

        public string UserEmail;
        public string Password;

        public User(string userEmail, string password)
        {
            UserEmail = userEmail;
            Password = password;
        }
    }
}