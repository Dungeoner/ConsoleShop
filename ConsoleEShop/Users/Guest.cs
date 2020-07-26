using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Linq.Expressions;

namespace ConsoleEShop
{
    class Guest : User
    {
        public Guest(string userName, int id) : base(userName, id)
        {
        }
    }
}
