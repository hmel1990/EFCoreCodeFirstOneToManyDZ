using EFCoreCodeFirstOneToManyDZ;
using EFCoreCodeFirstOneToManyDZ.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreCodeFirstOneToManyDZ
{
    internal class Program
    {
        static void Main()
        {
            //var ct = new CategoryRepository();
            //ct.AddCategory("Молочные продукты");
            var usr = new UserRepository();
            //usr.AddUser("Max", "111", "customer");
            //usr.AddUser("Alex", "111", "customer");
            //usr.AddUser("Igor", "111", "customer");
            //usr.AddUser("Daniel", "111", "customer");
            //usr.AddUser("Sasha", "111", "customer");
            //usr.AddUser("Maria", "111", "customer");

            //var prt = new ProductRepository();
            //prt.AddProduct("Молочные продукты", "молоко", 10, 2, "Гормолзавод");
            var rvw = new ReviewRepository();
            //rvw.AddReview("text1");
            //rvw.AddReview("text2");
            //rvw.AddReview("text3");
            //rvw.AddReview("text4");
            //rvw.AddReview("text5");
            //rvw.AddReview("text6");

            usr.GetAllPeopleWithReviews();

        }
    }
}
