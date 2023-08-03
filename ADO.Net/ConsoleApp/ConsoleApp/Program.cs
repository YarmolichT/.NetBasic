using System;
using System.Collections.Generic;
using CL_Structure;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository<ProductEntity>();

            var product = new ProductEntity()
            {
                 Name = "Pineapple",
                 Description = "Sweet",
                 Weight = 1,
                 Height = 1,
                 Length = 10,
                 Width = 10
            };

            productRepository.InsertItem(product);

            productRepository.UpdateItem(new ProductEntity()
            {
                 Product_Id = 2,
                 Name = "New fruit",
                 Description = "Green fruits",
                 Weight = 20,
                 Height = 10,
                 Length = 1,
                 Width = 1
            });

            var searchedProduct = productRepository.SelectItemById(2);
            Console.WriteLine(searchedProduct);

            var fullProductsList = productRepository.SelectAll();
            ShowProducts(fullProductsList);

            productRepository.DeleteItem(5);

            var orderRepository = new OrderRepository<OrderEntity>();
            
            var order = new OrderEntity()
            {
                Status = Status.NotStarted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Product_Id = 1
            };

            orderRepository.InsertItem(order);
            
            orderRepository.UpdateItem(new OrderEntity()
            {
                Orderd_Id = 2,
                Status = Status.Loading,
                UpdatedDate = DateTime.Today,
                Product_Id = 3
            });

            var searchedOrder = orderRepository.SelectItemById(2);
            Console.WriteLine(searchedOrder);

            var fullOrdersList = orderRepository.SelectAll();
            ShowOrders(fullOrdersList);

            orderRepository.DeleteItem(1);

            var orderFiltered = orderRepository.SelectByFilter("Status", 1);
            ShowOrders(orderFiltered);

            var orderFiltered1 = orderRepository.SelectByFilter("Product", 2);
            ShowOrders(orderFiltered1);

            var orderFiltered2 = orderRepository.SelectByFilter("Month", 8);
            ShowOrders(orderFiltered2);

            var orderFiltered3 = orderRepository.SelectByFilter("Year", 2023);
            ShowOrders(orderFiltered3);
        }

        private static void ShowProducts(List<ProductEntity> products)
        {
            Console.WriteLine("\n List of Products: \n");
            foreach (var entity in products)
            {
                Console.WriteLine(entity);
            }
        }

        private static void ShowOrders(List<OrderEntity> orders)
        {
            Console.WriteLine("\n List of Orders: \n");
            foreach (var orderEntity in orders)
            {
                Console.WriteLine(orderEntity);
            }
        }
    }
}
