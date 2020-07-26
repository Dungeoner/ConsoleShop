using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class SessionFactory
    {
        public ISession Selection(IDataBase dataBase, User user = null)
        {
            
            switch (user)
            {
                case null: 
                    return new GuestSession(dataBase);
                case RegisteredUser registeredUser:
                    return new UserSession(dataBase, registeredUser);
                case Administrator admin:
                    return new AdminSession(admin, dataBase);

            }

            return null;
        }

    }
}
