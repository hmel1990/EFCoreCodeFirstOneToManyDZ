
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstOneToManyDZ.Repositories
{
    public class ProductRepository
    {
        public MyDbContext context = new MyDbContext();

        public void AddProduct(string category, string name, float price, int quantity, string producer)
        {

            var cat = context.Categories?.FirstOrDefault(c=>c.Name == category);
            if (cat == null)
            {
                cat = new Category { Name = category };
                context.Categories.Add(cat);
                context.SaveChanges();
            }

            var prod = context.Producers?.FirstOrDefault(p => p.Name == producer);
            if (prod == null)
            {
                prod = new Producer { Name = producer};
                context.Producers.Add(prod);
                context.SaveChanges();
            }

            var product = new Product {Name = name, Price = price, Quantity = quantity, IdCategory = cat.Id, IdProducer = prod.Id};
            

            context.Products.Add(product);
            context.SaveChanges();
        }
        public List<Product>? GetAll()
        {
            var ListOfProducts = context.Products?.ToList();
            foreach (var item in ListOfProducts!)
            {
                Console.WriteLine("Наименование \t цена \t количество");
                Console.WriteLine($"{item.Name}\t {item.Price}\t {item.Quantity}");
            }
            return ListOfProducts;
        }
        public Product GetById(int id)
        {
            var prt = context.Products.FirstOrDefault(p => p.Id == id);
            Console.WriteLine($"{prt.Name}\t {prt.Price}\t {prt.Quantity}");
            return prt;
        }
        public void Update(string name, float price, int quantity)
        {
            var prt = context.Products.FirstOrDefault(p => p.Name == name);
            prt.Price = price;
            prt.Quantity = quantity;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("продукт не найден");
                return;
            }
            context.Products.Remove(product);
            context.SaveChanges();
        }

    }
}
