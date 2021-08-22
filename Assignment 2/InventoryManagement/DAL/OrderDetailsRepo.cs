using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetailsRepo
    {
        static Inventory2Entities context;
        static OrderDetailsRepo()
        {
            context = new Inventory2Entities();
        }

        public static List<OrderDetail> GetOrderDetails(string invoice)
        {
            return context.OrderDetails.Where(e => e.InvoiceNumber == invoice).ToList();
        }
        public static void AddOrderDetails(OrderDetail d)
        {
            context.OrderDetails.Add(d);
            context.SaveChanges();
        }


        public static void DeleteOrderDetails(int Id)
        {
            var pr = context.OrderDetails.FirstOrDefault(e => e.Id == Id);
            context.OrderDetails.Remove(pr);
            context.SaveChanges();
        }



    }
}
