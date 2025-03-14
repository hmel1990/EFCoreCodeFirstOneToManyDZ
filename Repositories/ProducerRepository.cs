using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Context;
using EFCoreCodeFirstOneToManyDZ;

namespace EFCoreCodeFirstOneToManyDZ.Repositories
{
    public class ProducerRepository
    {
        public MyDbContext context = new MyDbContext();

        public void AddProducer(string name)
        {
            var prr = new Producer { Name = name };

            context.Producers.Add(prr);
            context.SaveChanges();
        }
        public List<Producer>? GetAll()
        {
            var ListOfProducers = context.Producers?.ToList();
            foreach (var item in ListOfProducers)
            {

                Console.WriteLine("Наименование");
                Console.WriteLine($"{item.Name}");
            }
            return ListOfProducers;
        }
        public Producer GetById(int id)
        {
            var prr = context.Producers.FirstOrDefault(p => p.Id == id);

            Console.WriteLine("Наименование");
            Console.WriteLine($"{prr.Name}");
            return prr;
        }
        public void Update(int id, string name)
        {
            var prr = context.Producers.FirstOrDefault(o => o.Id == id);
            prr.Name = name;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var prr = context.Producers.FirstOrDefault(o => o.Id == id);

            if (prr == null)
            {
                Console.WriteLine("производитель не найден");
                return;
            }
            context.Producers.Remove(prr);
            context.SaveChanges();
        }
    }
}
