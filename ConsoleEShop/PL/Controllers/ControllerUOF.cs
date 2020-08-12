using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Interfaces;
using ConsoleEShop.PL.Management;

namespace ConsoleEShop.PL.Controllers
{
    public class ControllerUOF
    {
        private readonly IRepositoryUnitOfWork _context;
        private AccountManager _accountManager;
        private ProductController _productManager;
        private OrderController _orderManager;

        public ControllerUOF(IDataBase dataBase)
        {
            _context = new CollectionUnitOfWork(dataBase);
        }

        public AccountManager AccountManager => _accountManager ?? new AccountManager(new AccountService(_context));
        public ProductController ProductManager => _productManager ?? new ProductController(new ProductService(_context));
        public OrderController  OrderManager => _orderManager ?? new OrderController(new OrderService(_context), new ProductService(_context));

    }
}
