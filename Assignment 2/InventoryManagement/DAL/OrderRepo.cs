using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepo
    {
        static Inventory2Entities context;
        static OrderRepo()
        {
            context = new Inventory2Entities();
        }

        public static List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
        public static void CreateOrder(Order d)
        {
            context.Orders.Add(d);
            context.SaveChanges();
        }

        public static void CleanOrder()
        {

            var cart = GetOrders();
            foreach (var d in cart)
            {
                context.Orders.Remove(d);
                context.SaveChanges();
            }
        }

        public static Order GetOrder(string invoice)
        {
            return context.Orders.FirstOrDefault(e => e.InvoiceNumber == invoice);
        }

        public static Order GetOrder(int invoice)
        {
            return context.Orders.FirstOrDefault(e => e.Id == invoice);
        }

        public static void DeleteOrder(int Id)
        {
            var pr = context.Orders.FirstOrDefault(e => e.Id == Id);
            context.Orders.Remove(pr);
            context.SaveChanges();
        }

    }
}
