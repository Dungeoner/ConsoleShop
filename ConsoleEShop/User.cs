using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Users;

namespace ConsoleEShop
{
    class User
    {

        public User(string userName, UserType type, int id)
        {
            UserName = userName;
            Id = id;
            Type = type;
        }
        public string UserName { get; set; }
        public UserType Type { get; set; }
        public int Id { get; set; }

    }
}
