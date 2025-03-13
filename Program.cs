using EFCoreCodeFirstOneToManyDZ.Models;
using EFCoreCodeFirstOneToManyDZ.Repositories;

namespace EFCoreCodeFirstOneToManyDZ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //using (var context = new MyDbContext())
            //{
            //    var c = new Category() { Name = "TEST" };
            //    context.Categories.Add(c);
            //    context.SaveChanges();

            //    var categories = context.Categories
            //                            .Where(c => c.Id > 0)
            //                            .ToList();


            //    foreach (var category in categories)
            //    {
            //        Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            //    }
            //}
            var ct = new CategoryRepository();
            ct.AddCategory("Молочные продукты");
            var usr = new UserRepository();
            usr.AddUser("Max", "111", "customer");
            var prt = new ProductRepository();
            prt.AddProduct("Молочные продукты", "молоко", 10, 2, "Гормолзавод");
            var rvw = new ReviewRepository();
            rvw.AddReview("текст");
        }
    }
}
