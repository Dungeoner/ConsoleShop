using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.DAL.Entities
{
    public class Order
    {
        public Order(Product product, User user, int orderId)
        {
            Product = product;
            User = user;
            OrderId = orderId;
            Status = OrderStatus.New;
        }

        public OrderStatus Status { get; set; }
        public Product Product { get; }
        public int OrderId { get; }
        public User User { get; }
    }


}
