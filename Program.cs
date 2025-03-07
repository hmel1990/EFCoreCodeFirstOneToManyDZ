using EFCoreCodeFirstOneToManyDZ.Models;

namespace EFCoreCodeFirstOneToManyDZ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (var context = new MyDbContext())
            {
                var c = new Category() { Name = "TEST" };
                context.Categories.Add(c);
                context.SaveChanges();

                var categories = context.Categories
                                        .Where(c => c.Id > 0)
                                        .ToList();


                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
                }
            }
        }
    }
}
