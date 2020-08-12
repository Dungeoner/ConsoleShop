using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop.BLL
{
    class UserInputException : Exception
    {
        public UserInputException(string message) : base(message) { }
    }
}
