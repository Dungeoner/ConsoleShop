using ConsoleEShop.DAL;

namespace ConsoleEShop.BLL
{
    public class ServiceUnitOfWork
    {
        private readonly CollectionUnitOfWork _context;
        private AccountService _accountService;
        private ProductService _productService;
        private OrderService _orderService;

        public AccountService AccountService => _accountService ?? new AccountService(_context);
        public ProductService ProductService => _productService ?? new ProductService(_context);
        public OrderService OrderService => _orderService ?? new OrderService(_context);

        public ServiceUnitOfWork()
        {
            _context = new CollectionUnitOfWork();
        }
    }
}
