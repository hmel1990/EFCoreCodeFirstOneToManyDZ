using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Models;

namespace EFCoreCodeFirstOneToManyDZ.Repositories
{
    internal class CategoryRepository
    {
        public MyDbContext context = new MyDbContext();

        public void AddProducer(string name)
        {
            var ctg = new Category { Name = name };

            context.Categories.Add(ctg);
            context.SaveChanges();
        }
        public List<Category>? GetAll()
        {
            var ListOfCategories = context.Categories?.ToList();
            foreach (var item in ListOfCategories)
            {

                Console.WriteLine("Наименование");
                Console.WriteLine($"{item.Name}");
            }
            return ListOfCategories;
        }
        public Category GetById(int id)
        {
            var ctg = context.Categories.FirstOrDefault(p => p.Id == id);

            Console.WriteLine("Наименование");
            Console.WriteLine($"{ctg.Name}");
            return ctg;
        }
        public void Update(int id, string name)
        {
            var ctg = context.Categories.FirstOrDefault(o => o.Id == id);
            ctg.Name = name;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var ctg = context.Categories.FirstOrDefault(o => o.Id == id);

            if (ctg == null)
            {
                Console.WriteLine("производитель не найден");
                return;
            }
            context.Categories.Remove(ctg);
            context.SaveChanges();
        }
    }
}
