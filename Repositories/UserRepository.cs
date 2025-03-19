using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstOneToManyDZ.Context;
using EFCoreCodeFirstOneToManyDZ;


namespace EFCoreCodeFirstOneToManyDZ.Repositories
{
    internal class UserRepository
    {
        public MyDbContext context = new MyDbContext();

        public void AddUser(string username, string password, string access)
        {
            var user = new User { Username = username, Password = password, Access = access};

            context.Users.Add(user);
            context.SaveChanges();
        }
        public List<User>? GetAll()
        {
            var ListOfUsers = context.Users?.ToList();
            foreach (var item in ListOfUsers!)
            {
                Console.WriteLine("Наименование \t цена \t количество");
                Console.WriteLine($"{item.Username}\t {item.Password}\t {item.Access}");
            }
            return ListOfUsers;
        }


        public void GetAllPeopleWithReviews()
        {

            var people = context.Users?.ToList(); // загружаем людей

            foreach (var user in people)
            {
                Console.WriteLine($"Человек: {user.Username}");

                //отложенная загрузка: увлечения загружаются только при обращении к ним
                foreach (var review in user.Reviews)
                {
                    Console.WriteLine($"Отзыв: {review.Text}");
                }
            }
        }


        public User GetById(int id)
        {
            var usr = context.Users.FirstOrDefault(u => u.Id == id);
            Console.WriteLine($"{usr.Username}\t {usr.Password}\t {usr.Access}");
            return usr;
        }
        public void Update(string name, string access)
        {
            var usr = context.Users.FirstOrDefault(u => u.Username == name);
            usr.Access = access;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var usr = context.Users.FirstOrDefault(p => p.Id == id);
            if (usr == null)
            {
                Console.WriteLine("продукт не найден");
                return;
            }
            context.Users.Remove(usr);
            context.SaveChanges();
        }
    }
}
