using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ProductRepo
    {
        static Inventory2Entities context;
        static ProductRepo()
        {
            context = new Inventory2Entities();
        }
        public static void AddProduct(Product model)
        {
            context.Products.Add(model);
            context.SaveChanges();
        }
        public static List<Product> GetAllProducts()
        {
            var data = context.Products.ToList();
            return data;
        }
        public static Product GetProduct(int id)
        {
            var data = context.Products.FirstOrDefault(e => e.Id == id);
            return data;
        }

        public static List<string> GetProductNames()
        {
            var data = context.Products.Select(e => e.Name).ToList();
            return data;
        }

        public static void EditProduct(Product p)
        {
            var oldp = context.Products.FirstOrDefault(e => e.Id == p.Id);
            /*oldp.Name = p.Name;
            //manually change
            context.Entry(oldp).State = System.Data.Entity.EntityState.Modified;*/
            context.Entry(oldp).CurrentValues.SetValues(p);
            context.SaveChanges();
        }

        public static void DeleteProduct(int Id)
        {
            var pr = context.Products.FirstOrDefault(e => e.Id == Id);
            context.Products.Remove(pr);
            context.SaveChanges();
        }
    }
}
