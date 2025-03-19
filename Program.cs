using EFCoreCodeFirstOneToManyDZ;
using EFCoreCodeFirstOneToManyDZ.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace EFCoreCodeFirstOneToManyDZ
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            string connectionString = "Server=localhost;Database=MarketPlace;Trusted_Connection=True;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var product = new ProductRepository();

                product.AddProductDapper(connection, "testDapper", (float)10.00, 10);

                var products = product.GetAllDapper(connection);
                foreach (var prt in products)
                {
                    Console.WriteLine(prt.Name);
                }

                var prt2 = product.GetByIdDapper(connection, 3);
                Console.WriteLine(prt2.Name);

                product.UpdateDapper(connection, 3, "testDapperNew", (float)10.00, 10);

                product.DeleteDapper(connection, 3);
            }
        }
    }
}
