
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Context;
using EFCoreCodeFirstOneToManyDZ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        //for Dapper
        public void AddProductDapper(SqlConnection connection, string name, float price, int quantity)
        {
            var query = "INSERT INTO Product (name, price, quantity) VALUES (@Name, @Price, @Quantity)";
            connection.Execute(query, new { Name = name, Price = price, Quantity = quantity});
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

        //for Dapper
        public List<Product> GetAllDapper(SqlConnection connection)
        {
            var query = "SELECT * FROM Product";
            return connection.Query<Product>(query).ToList();
        }


        public Product GetById(int id)
        {
            var prt = context.Products.FirstOrDefault(p => p.Id == id);
            Console.WriteLine($"{prt.Name}\t {prt.Price}\t {prt.Quantity}");
            return prt;
        }

        //for Dapper
        public Product GetByIdDapper(SqlConnection connection, int id)
        {
            return connection.QuerySingleOrDefault<Product>("SELECT * FROM Product WHERE id = @Id", new { Id = id });
        }


        public void Update(string name, float price, int quantity)
        {
            var prt = context.Products.FirstOrDefault(p => p.Name == name);
            prt.Price = price;
            prt.Quantity = quantity;
            context.SaveChanges();
        }

        public void UpdateDapper (SqlConnection connection, int id, string name, float price, int quantity)
        {
            var query = "UPDATE Product SET name = @Name, price = @Price, quantity = @Quantity WHERE id = @Id";
            connection.Execute(query, new { Id = id, Name = name, Price = price, Quantity= quantity});
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

        public void DeleteDapper (SqlConnection connection, int id)
        {
            var query = "DELETE FROM Product WHERE id = @Id";
            connection.Execute(query, new { Id = id });
        }
    }
}
