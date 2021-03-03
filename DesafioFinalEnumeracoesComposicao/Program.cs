using DesafioFinalEnumeracoesComposicao.Entities;
using DesafioFinalEnumeracoesComposicao.Entities.Enums;
using System;
using System.Globalization;

namespace DesafioFinalEnumeracoesComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Client data
            Console.WriteLine("Enter clint data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            //Order data
            Console.WriteLine("Enter order data:");
            DateTime moment = DateTime.Now;
            Console.WriteLine();
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Client client = new Client(name, email, birthdate);
            Order order = new Order(moment, status, client);

            Console.Write("How many items to this order: ");
            int n = int.Parse(Console.ReadLine());
            //Items
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data");
                Console.Write("Product Name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double princeProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int nProduct = int.Parse(Console.ReadLine());

                Product product = new Product(nameProduct, princeProduct);
                OrderItem items = new OrderItem(nProduct, princeProduct, product);
                order.AddItem(items);
            }

            Console.WriteLine(order);
        }
    }
}
