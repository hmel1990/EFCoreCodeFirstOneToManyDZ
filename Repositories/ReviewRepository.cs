using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Context;
using EFCoreCodeFirstOneToManyDZ.Models;

namespace EFCoreCodeFirstOneToManyDZ.Repositories
{
    internal class ReviewRepository
    {
        public MyDbContext context = new MyDbContext();

        public void AddReview(string review)
        {
            var rvw = new Review { Text = review };
            context.Reviews.Add(rvw);
            context.SaveChanges();
        }
        public List<Review>? GetAll()
        {
            var ListOfReviews = context.Reviews?.ToList();
            foreach (var item in ListOfReviews)
            {
                var product = context.Products.FirstOrDefault(p => p.Id == item.IdProduct);
                var user = context.Users.FirstOrDefault(p => p.Id == item.IdUser);


                Console.WriteLine("пользователь \t товар \t отзыв");
                Console.WriteLine($"{user.Username} \t {product.Name} \t {item.Text}");
            }
            return ListOfReviews;
        }
        public Review GetById(int id)
        {
            var rvw = context.Reviews.FirstOrDefault(p => p.Id == id);
            var product = context.Products.FirstOrDefault(p => p.Id == rvw.IdProduct);
            var user = context.Users.FirstOrDefault(p => p.Id == rvw.IdUser);

            Console.WriteLine("пользователь \t товар \t отзыв");
            Console.WriteLine($"{user.Username} \t {product.Name} \t {rvw.Text}");
            return rvw;
        }
        public void Update(int id, string text)
        {
            var rvw = context.Reviews.FirstOrDefault(o => o.Id == id);
            rvw.Text = text;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var rvw = context.Reviews.FirstOrDefault(o => o.Id == id);
            if (rvw == null)
            {
                Console.WriteLine("отзыв не найден");
                return;
            }
            context.Reviews.Remove(rvw);
            context.SaveChanges();
        }
    }
}
