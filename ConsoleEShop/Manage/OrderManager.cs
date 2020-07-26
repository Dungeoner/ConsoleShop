using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class OrderManager
    {
        public OrderManager(IDataBase database)
        {
            _dataBase = database;
        }

        private IDataBase _dataBase;
        public void Create(User user, Product product)
        {
            _dataBase.AddOrder(new Order(product, user.Id));
        }

        public List<Order> OrderHistory(User user)
        {
            return _dataBase.GetOrderList().FindAll(x => x.UserId == user.Id);
        }

        public void Cancel(Order order, User user)
        {
            if(order.UserId != user.Id) throw new ArgumentException("Id doesn't match");
            OrderHistory(user).Find(x => x == order).Status = OrderStatus.CanceledByUser;
        }

        public void ChangeStatus(Order order, Administrator admin, OrderStatus orderStatus)
        {
            if(order == null) throw new ArgumentNullException(nameof(order));
            _dataBase.GetOrderList().Find(x => x == order).Status = orderStatus;
        }

}
}
