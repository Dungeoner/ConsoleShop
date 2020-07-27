using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    public class ShopWork
    {
        //public event AccountHandler Login;
        //public event AccountHandler Register;
        //public event AccountHandler Logout;
        ////public event ProductHandler ViewProductList;
        //public event ProductListHandler FindProduct;


        private readonly IDataBase _dataBase;
        private readonly User _user = new User("Guest", UserType.Guest, 0);
        public ShopWork(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }


        public void Start()
        {
            var accountManager = new AccountManager(_dataBase);
            var productManager = new ProductManager(_dataBase);
            var orderManager = new OrderManager(_dataBase);
            ProductHandler viewProductList = productManager.ProductView;
            AccountHandler Login = accountManager.Login;
            AccountHandler Register = accountManager.Register;
            AccountHandler Logout = accountManager.Loguot;
            ProductHandler FindProduct = productManager.Search;


            switch (_user.Type)
            {
                case UserType.Guest:
                    Guest(viewProductList, Login, Register, Logout, FindProduct);
                    break;
                case UserType.User:
                    User();
                    break;
                case UserType.Admin:
                    Admin();
                    break;
                default: break;
            }
            
        }

        private void Guest(ProductHandler viewProductList, AccountHandler login, AccountHandler register, AccountHandler logout, ProductHandler findProduct)
        {
            while (true)
            {
                Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for login \n\t 4 for register \n\t any key for exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        viewProductList.Invoke();
                        continue;
                    case "2":
                        findProduct.Invoke();
                        break;
                    case "3":
                        login.Invoke();
                        break;
                    case "4":
                        register.Invoke();
                        break;
                    default:
                        break;
                }

                break;
            }
        }

        private void User()
        {

        }

        private void Admin()
        {

        }

    }
}
