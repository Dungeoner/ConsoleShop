using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Users;

namespace ConsoleEShop
{
    class GuestSession : ISession
    {
        public GuestSession(IDataBase dataBase)
        {
            user = new User("Guest", UserType.Guest, 0);
            _dataBase = dataBase;

        }
        public User user { get; set; }
        private readonly IDataBase _dataBase;


        public ISession Run()
        {
            Console.WriteLine("Press: \n \t 1 for View products \n 2 for search \n 3 for login \n 4 for register \n any key for exit");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                {
                    var productManage = new ProductManager(_dataBase);
                    productManage.ProductView();
                    break;
                }

                case 2:
                {
                    var productManage = new ProductManager(_dataBase);
                    var i = 1;
                    Console.WriteLine("Enter name of product");
                    foreach (var product in productManage.Search(Console.ReadLine()))
                    {
                        Console.WriteLine($"{i} {product}");
                        i++;
                    }

                    break;
                }

                case 3:
                {
                    try
                    {
                        var account = new Account(_dataBase);
                        var user = account.Login();
                        switch (user)
                        {
                            case RegisteredUser registeredUser:
                                return new UserSession(registeredUser);
                            case Administrator admin:
                                return new AdminSession(admin);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Run();
                    }

                    break;

                }

                case 4:
                {
                    try
                    {
                        var account = new Account(_dataBase);
                        return new UserSession((RegisteredUser) account.Register());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Run();
                    }

                    break;
                }
            }

            return null;
        }
    }
}
