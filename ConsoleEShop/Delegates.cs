using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ConsoleEShop
{
    public delegate User AccountHandler();

    public delegate void AccountDataChange(User user);

    public delegate void ViewUSerData();

    public delegate void ProductHandler();

    public delegate void OrderHistory(User user);

    public delegate void Menu();

    public delegate void OrderHandler(User user);



}
