using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    abstract class User
    {

        public User(string userName, int id)
        {
            UserName = userName;
            Id = id;
        }
        public string UserName { get; set; }
        public int Id { get; set; }
    }
}
