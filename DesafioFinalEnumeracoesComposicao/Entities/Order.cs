using DesafioFinalEnumeracoesComposicao.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DesafioFinalEnumeracoesComposicao.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem items)
        {
            Items.Add(items);
        }

        public void RemoveItem(OrderItem items)
        {
            Items.Remove(items);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem items in Items)
            {
                sum += items.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY");
            sb.Append("Order moment: ");
            sb.AppendLine(Date.ToString());
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client.Name + " " + Client.BirthDate.ToString("(dd/MM/yyyy)") + " - " + Client.Email);
            sb.AppendLine("Order items:");
            foreach (OrderItem items in Items)
            {
                sb.Append(items.Product.Name + ", ");
                sb.Append(items.Product.Price + ", ");
                sb.Append("Quantity: " + items.Quantity + ", ");
                sb.AppendLine("Subtotal: " + items.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            Console.WriteLine();
            sb.AppendLine("Total prince: " + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
