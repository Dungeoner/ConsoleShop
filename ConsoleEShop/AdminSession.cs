using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class AdminSession : ISession
    {
        public AdminSession(Administrator admin, IDataBase dataBase)
        {
            _dataBase = dataBase;
            Admin = admin;
        }
        public Administrator Admin { get; set; }
        private IDataBase _dataBase;
        public ISession Run()
        {
            throw new NotImplementedException();
        }
    }
}
