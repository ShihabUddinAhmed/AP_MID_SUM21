using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CartRepo
    {
        static Inventory2Entities context;
        static CartRepo()
        {
            context = new Inventory2Entities();
        }
        
        public static List<CartTable> GetCarts()
        {
            return context.CartTables.ToList();
        }
        public static void AddToCart(CartTable d)
        {
            context.CartTables.Add(d);
            context.SaveChanges();
        }

        public static CartTable GetCart(int id)
        {
            var data = context.CartTables.FirstOrDefault(e => e.Id == id);
            return data;
        }

        public static void CleanCart()
        {

            var cart = GetCarts();
            foreach (var d in cart)
            {
                context.CartTables.Remove(d);
                context.SaveChanges();
            }
        }

        public static CartTable GetCartItem(int id)
        {
            return context.CartTables.FirstOrDefault(e => e.Id == id);
        }

        public static void DeleteCartItem(int id)
        {
            //return context.CartTables.Remove(e => e.Id == id);
            var d = GetCartItem(id);
            context.CartTables.Remove(d);
            context.SaveChanges();

        }

        public static void EditCart(CartTable p)
        {
            var oldp = context.CartTables.FirstOrDefault(e => e.Id == p.Id);
            /*oldp.Name = p.Name;
            //manually change
            context.Entry(oldp).State = System.Data.Entity.EntityState.Modified;*/
            context.Entry(oldp).CurrentValues.SetValues(p);
            context.SaveChanges();
        }
    }
}
