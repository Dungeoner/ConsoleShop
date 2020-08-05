using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    public class ConsoleUI
    {
        public event AccountHandler Login;
        public event AccountHandler Register;
        public event AccountDataChange AccountDataChange;
        public event ViewUSerData ViewUSerData;

        public event ProductHandler ViewProductList;
        public event ProductHandler FindProduct;
        public event ProductHandler AddProduct;
        public event ProductHandler ChangeProductData;

        public event OrderHandler CreateOrder;
        public event OrderHistory OrderHistory;
        public event OrderHandler ChangeOrderStatus;
        
        private readonly IDataBase _dataBase;
        private Menu menu;
        private User _user;
        public ConsoleUI(IDataBase dataBase)
        {
            _dataBase = dataBase;
            menu = DefaultMenu;
            _user = null;
        }
        public void Start()
        {
            var accountOperations = new AccountManager(_dataBase);
            var productOperations = new ProductManager(_dataBase);
            var orderOperations = new OrderManager(_dataBase);
            Login = accountOperations.Login;
            Register = accountOperations.Register;
            FindProduct = productOperations.Search;
            ViewProductList = productOperations.ProductView;
            CreateOrder = orderOperations.Create;
            OrderHistory = orderOperations.OrderHistory;
            ChangeOrderStatus = orderOperations.ChangeStatus;
            AccountDataChange = accountOperations.ChangeData;
            AddProduct = productOperations.AddProduct;
            ChangeProductData = productOperations.ChangeProductData;
            menu.Invoke();
        }

        private void DefaultMenu()
        {
            Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for login \n\t 4 for register \n\t any key for exit");
            switch (Console.ReadLine())
            {
                case "1":
                    ViewProductList?.Invoke();
                    menu.Invoke();
                    break;
                case "2":
                    FindProduct?.Invoke();
                    menu.Invoke();
                    break;
                case "3":
                    _user = Login?.Invoke();

                    switch (_user.Type)
                    {
                        case UserType.User:
                            menu = UserMenu;
                            break;
                        case UserType.Admin:
                            menu = AdminMenu;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    menu?.Invoke();
                    break;
                case "4":
                    _user = Register?.Invoke();
                    switch (_user.Type)
                    {
                        case UserType.User:
                            menu = UserMenu;
                            break;
                        case UserType.Admin:
                            menu = AdminMenu;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    menu?.Invoke();
                    break;
                default:
                    break;
                    
            }
            }

        private void UserMenu()
        {
            Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for create new order \n\t 4 for view your order history" +
                              " \n\t 5  for cancel processed order \n\t 6 for change your personal data \n\t 7 for logout  \n\t any key for exit");
            switch (Console.ReadLine())
            {
                case "1":
                    ViewProductList?.Invoke();
                    menu.Invoke();
                    break;
                case "2":
                    FindProduct?.Invoke();
                    menu.Invoke();
                    break;
                case "3":
                    CreateOrder?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "4":
                    OrderHistory?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "5":
                    ChangeOrderStatus?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "6":
                    AccountDataChange?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "7":
                    menu = DefaultMenu;
                    menu.Invoke();
                    break;
                default: break;
            }
        }

        private void AdminMenu()
        {
            Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for create new order \n\t 4 for order history" +
                              " \n\t 5 for change order status \n\t 6 for view user data \n\t 7 for change user data \n\t 8 for add new product \n\t 9 for change product info" +
                              " \n\t 10 for logout  \n\t any key for exit");
            switch (Console.ReadLine())
            {
                case "1":
                    ViewProductList?.Invoke();
                    menu.Invoke();
                    break;
                case "2":
                    FindProduct?.Invoke();
                    menu.Invoke();
                    break;
                case "3":
                    CreateOrder?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "4":
                    OrderHistory?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "5":
                    ChangeOrderStatus?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "6":
                    ViewUSerData?.Invoke();
                    menu.Invoke();
                    break;
                case "7":
                    AccountDataChange?.Invoke(_user);
                    menu.Invoke();
                    break;
                case "8":
                    AddProduct?.Invoke();
                    menu.Invoke();
                    break;
                case "9":
                    ChangeProductData?.Invoke();
                    menu.Invoke();
                    break;
                case "10":
                    menu = DefaultMenu;
                    menu.Invoke();
                    break;
                default: break;
            }

        }

    }
}
