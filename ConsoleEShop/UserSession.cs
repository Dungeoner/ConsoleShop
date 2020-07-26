using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class UserSession : ISession
    {
        public UserSession(IDataBase dataBase, RegisteredUser user)
        {
            _dataBase = dataBase;
            User = user;
        }
        public RegisteredUser User { get; set; }
        private IDataBase _dataBase;
        public ISession Run()
        {
            throw new NotImplementedException();
        }
    }
}
