using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using EFCoreCodeFirstOneToManyDZ.Context;

namespace EFCoreCodeFirstOneToManyDZ.Tests
{
    [TestFixture] // так в NUnit помечаются тестовые классы
    public class UserRepositoryTests
    {
        private ApplicationDbContext? _context;
        [SetUp] // этот метод выполняется перед каждым тестом
        public void SetUp()
        {
            // используем InMemory базу данных для тестирования
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Test]
        public void AddUser_ShouldReturnPeople()
        {
            // подготоваливаем данные
            string _Username = "Max", _Password = "111", _Access = "access";
               

            // извлекаем
            var user = new User { Username = _Username, Password = _Password, Access = _Access };
            _context?.Users.Add(user);
            _context?.SaveChanges();

            // проверки
            Assert.That(_context.Users.Count, Is.EqualTo(1));
            Assert.That(_context.Users.FirstOrDefault().Username, Is.EqualTo("Max"));
            Assert.That(_context.Users.FirstOrDefault().Password, Is.EqualTo("111"));
            Assert.That(_context.Users.FirstOrDefault().Access, Is.EqualTo("access"));
        }

        [Test]
        public void GetById_ShouldReturnPeopleWithId()
        {
            int id = 2;
            var user = new User { Username = "Max", Password = "111", Access = "access" };
            _context?.Users.Add(user);
            user = new User { Username = "Alex", Password = "222", Access = "customer" };
            _context?.Users.Add(user);
            _context?.SaveChanges();

            var result = _context.Users.FirstOrDefault(u => u.Id == id);

            Assert.That(result.Username, Is.EqualTo("Alex"));
            Assert.That(result.Password, Is.EqualTo("222"));
            Assert.That(result.Access, Is.EqualTo("customer"));
        }

        [Test]
        public void Update_ShouldUpdateUserWithName()
        {
            string name = "Alex", access = "admin";

            var user = new User { Username = "Max", Password = "111", Access = "access" };
            _context?.Users.Add(user);
            user = new User { Username = "Alex", Password = "222", Access = "customer" };
            _context?.Users.Add(user);
            _context?.SaveChanges();

            var result = _context.Users.FirstOrDefault(u => u.Username == name);
            result.Access = access;
            _context.SaveChanges();

            Assert.That(result.Access, Is.EqualTo("admin"));
        }

        [Test]
        public void Delete_ShouldDeleteUserWithId()
        {
            int id = 1;
            var user = new User { Username = "Max", Password = "111", Access = "access" };
            _context?.Users.Add(user);
            user = new User { Username = "Alex", Password = "222", Access = "customer" };
            _context?.Users.Add(user);
            _context?.SaveChanges();

            var usr = _context.Users.FirstOrDefault(p => p.Id == id);
            _context.Users.Remove(usr);
            _context.SaveChanges();

            Assert.That(_context.Users.Count, Is.EqualTo(1));

        }

        [TearDown]
        public void TearDown()
        {
            _context?.Database.EnsureDeleted();
        }


    }
}
