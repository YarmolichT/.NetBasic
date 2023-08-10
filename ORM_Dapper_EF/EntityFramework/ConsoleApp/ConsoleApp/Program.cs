using CL_Structure_EF;

namespace ConsoleApp
{
    internal class Program
    {
        private static void ShowOrders(List<OrderModel> orders)
        {
            Console.WriteLine("\n List of Orders: \n");

            foreach (var orderEntity in orders)
            {
                Console.WriteLine(orderEntity);
            }
        }

        private static void ShowProducts(List<ProductModel> products)
        {
            Console.WriteLine("\n List of Products: \n");

            foreach (var entity in products)
            {
                Console.WriteLine(entity);
            }
        }

        static void Main(string[] args)
        {
            var productRepo = new ProductRepository();
            var orderRepository = new OrderRepository();

            // Operations with Product

            productRepo.Delete(8012);
            
            productRepo.Create(new ProductModel()
            {
                Description = "Description",
                Height = 1,
                Length = 1,
                Name = "name",
                Weight = 1,
                Width = 1,
            });

            var product = productRepo.Get(8005);
            Console.WriteLine(product);

            product.Description = "Description_Description";
            product.Height = 1;
            product.Length = 1;
            product.Name = "Name";
            product.Weight = 1;
            product.Width = 1;

            productRepo.Update(product);
            var productList = productRepo.GetItems();
            ShowProducts(productList);

            var productModelsAfterDeletion = productRepo.GetItems();
            ShowProducts(productModelsAfterDeletion);

           // Operations with Order
            
            orderRepository.Delete(12012);

            orderRepository.Create(new OrderModel()
            {
                Status = 0,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Product_Id = 2
            });

            var order = orderRepository.Get(9006);
            Console.WriteLine(order);

            order.Status = 5;
            order.UpdatedDate = DateTime.Now;
            order.Product_Id = 3;

            orderRepository.Update(order);
            Console.WriteLine(order);
            
            var orderList = orderRepository.GetItems();
            ShowOrders(orderList);

            var ordersModelsAfterDeletion = orderRepository.GetItems();
            ShowOrders(ordersModelsAfterDeletion);

            var t = orderRepository.SelectByFilter("status", 5);
            ShowOrders(t);

            orderRepository.DeleteBulk("status", 5);
            ShowOrders(orderRepository.GetItems());
        }
    }
}