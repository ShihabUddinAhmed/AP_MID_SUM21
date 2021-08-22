using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CartService
    {
        public static List<CartModel> GetCarts()
        {
            var orders = CartRepo.GetCarts();
            var data = AutoMapper.Mapper.Map<List<CartTable>, List<CartModel>>(orders);
            /* List<CategoryModel> data = new List<CategoryModel>();
             foreach (var d in Categorys) {
                 var dm = new CategoryModel()
                 {
                     Id = d.Id,
                     Name = d.Name
                 };
                 data.Add(dm); 
             }*/
            return data;
        }
        public static void AddToCart(ProductModel e)
        {
            var pro = new CartModel();

            pro.ProductId = e.Id;
            pro.ProductName = e.Name;
            pro.Price = e.Price;
            pro.Qty = 1;
            pro.TotalPrice = e.Price;
          
            var d = AutoMapper.Mapper.Map<CartModel, CartTable>(pro);
            //var d = new Category() { Id = dept.Id, Name = dept.Name };
            CartRepo.AddToCart(d);
        }

        public static void AddToCart(CartModel e)
        {
            var d = AutoMapper.Mapper.Map<CartModel, CartTable>(e);
            //var d = new Category() { Id = dept.Id, Name = dept.Name };
            CartRepo.AddToCart(d);
        }

        public static CartModel GetCart(int id)
        {
            var data = CartRepo.GetCart(id);
            var st = AutoMapper.Mapper.Map<CartTable, CartModel>(data);
            return st;
        }

        public static void EditCart(CartModel model)
        {
            var data = AutoMapper.Mapper.Map<CartModel, CartTable>(model);
            CartRepo.EditCart(data);
        }

        public static void DeleteItem(int Id)
        {
            CartRepo.DeleteCartItem(Id);
        }
    }
}
