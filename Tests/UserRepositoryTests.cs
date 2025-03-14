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

        [Test] // таким аттрибутом помечаются все обычные тестовые методы
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


    }
}
