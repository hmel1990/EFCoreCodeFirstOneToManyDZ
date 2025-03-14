using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Context;
using EFCoreCodeFirstOneToManyDZ;

namespace EFCoreCodeFirstOneToManyDZ.Repositories
{
    public class OrderRepository
    {
        public MyDbContext context = new MyDbContext();

        public void AddOrder(int quantity)
        {
            var order = new Order { Quantity = quantity };

            context.Orders.Add(order);
            context.SaveChanges();
        }
        public List<Order>? GetAll()
        {
            var ListOfOrders = context.Orders?.ToList();
            foreach (var item in ListOfOrders)
            {
                var ordr = context.Products.FirstOrDefault(p => p.Id == item.IdProduct);

                Console.WriteLine("Наименование \t количество");
                Console.WriteLine($"{ordr.Name} \t {item.Quantity}");
            }
            return ListOfOrders;
        }
        public Order GetById(int id)
        {
            var ordr = context.Orders.FirstOrDefault(p => p.Id == id);
            var ordrName = context.Products.FirstOrDefault(p => p.Id == ordr.IdProduct);

            Console.WriteLine("Наименование \t количество");
            Console.WriteLine($"{ordrName.Name} \t {ordr.Quantity}");
            return ordr;
        }
        public void Update(int id, int quantity)
        {
            var ordr = context.Orders.FirstOrDefault(o => o.Id == id);
            ordr.Quantity = quantity;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var ordr = context.Orders.FirstOrDefault(o => o.Id == id);
            if (ordr == null)
            {
                Console.WriteLine("заказ не найден");
                return;
            }
            context.Orders.Remove(ordr);
            context.SaveChanges();
        }
    }
}
