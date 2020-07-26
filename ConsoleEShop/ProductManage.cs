using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class ProductManage
    {
        public ProductManage (IDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        private IDataBase _dataBase;
        public List<Product> ProductViev()
        {
            return _dataBase.GetProductList();
        }

        public void CreateOrder()
        {

        }
    }
}
