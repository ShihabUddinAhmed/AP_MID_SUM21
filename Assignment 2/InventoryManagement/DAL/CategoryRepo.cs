using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CategoryRepo
    {

        static Inventory2Entities context;
        static CategoryRepo()
        {
            context = new Inventory2Entities();
        }
        public static List<string> GetCategoryNames()
        {
            var data = context.Categories.Select(e => e.Name).ToList();
            return data;
        }
        public static List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public static void AddCategory(Category d)
        {
            context.Categories.Add(d);
            context.SaveChanges();
        }

        public static Category GetCategory(int id)
        {
            var data = context.Categories.FirstOrDefault(e => e.Id == id);
            return data;
        }

        public static Category GetCategoryDetail(int id)
        {
            return context.Categories.FirstOrDefault(e => e.Id == id);
        }

        public static void EditCategory(Category p)
        {
            var oldp = context.Categories.FirstOrDefault(e => e.Id == p.Id);
            /*oldp.Name = p.Name;
            //manually change
            context.Entry(oldp).State = System.Data.Entity.EntityState.Modified;*/
            context.Entry(oldp).CurrentValues.SetValues(p);
            context.SaveChanges();
        }

        public static void DeleteCategory(int Id)
        {
            var pr = context.Categories.FirstOrDefault(e => e.Id == Id);
            context.Categories.Remove(pr);
            context.SaveChanges();
        }
    }
}
