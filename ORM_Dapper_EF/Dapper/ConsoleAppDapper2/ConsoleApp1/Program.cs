using ClassLibrary1;

namespace ConsoleApp1
{
    public class Program
    {
        private static IRepository<Order> _orderRepository;
        
        private static IRepository<Product> _productRepository;

        private static void ShowOrders(List<Order> orders)
        {
            Console.WriteLine("\n List of Orders: \n");
            foreach (var orderEntity in orders)
            {
                Console.WriteLine(orderEntity);
            }
        }

        private static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("\n List of Products: \n");
            foreach (var entity in products)
            {
                Console.WriteLine(entity);
            }
        }

        static void Main(string[] args)
        {
            _orderRepository = new OrderRepository<Order>();
            _productRepository = new ProductRepository<Product>();

            var order = new Order()
            {
                Status = (int)Status.NotStarted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Product_Id = 1
            };

            _orderRepository.InsertItem(order);

            var orderForUpdate = new Order()
            {
                Orderd_Id = 1,
                Status = (int)Status.Done,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Product_Id = 1
            };

            _orderRepository.UpdateItem(orderForUpdate);

            var searchedOrder = _orderRepository.SelectItemById(1);
            Console.WriteLine(searchedOrder);

            var fullOrdersList = _orderRepository.SelectAll();
            ShowOrders(fullOrdersList);

            _orderRepository.DeleteItem(0);
             
            var product = new Product()
            {
                Name = "Green apple",
                Description = "Green apples",
                Weight = 50,
                Height = 1,
                Length = 0,
                Width = 0
            };

            _productRepository.InsertItem(product);

            _productRepository.UpdateItem(new Product()
            {
                Product_Id = 8,
                Name = "All green apple",
                Description = "Green apples",
                Weight = 20,
                Height = 10,
                Length = 1,
                Width = 1
            });

            var searchedProduct = _productRepository.SelectItemById(7);
            Console.WriteLine(searchedProduct);

            _productRepository.DeleteItem(8);

            var orderRepo = new OrderRepository<Order>();

            var selectByFilterStatus = orderRepo.SelectByFilter("status", (int)Status.Cancelled);
            Console.WriteLine("after filter by status");
            ShowOrders(selectByFilterStatus);

            var selectByFilterProductID = orderRepo.SelectByFilter("product", 6);
            Console.WriteLine("after filter productID");
            ShowOrders(selectByFilterProductID);

            var selectByFilterMonth = orderRepo.SelectByFilter("month", 8);
            Console.WriteLine("after filter month");
            ShowOrders(selectByFilterMonth);

            var selectByFilterYear = orderRepo.SelectByFilter("year", 2025);
            Console.WriteLine("after filter year");
            ShowOrders(selectByFilterYear);

            orderRepo.DeleteBulk("status", (int)Status.Loading );
            orderRepo.DeleteBulk("product", 7);
            orderRepo.DeleteBulk("month", 7);
            orderRepo.DeleteBulk("year", 2025);

            var resultAfterDelete = orderRepo.SelectAll();
            Console.WriteLine("After Bulk Delete:");
            ShowOrders(resultAfterDelete);
        }
    }
}