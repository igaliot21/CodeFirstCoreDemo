using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace CodeFirstCoreDemo
{
    class Program
    {
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        public class Order
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public Customer Customer { get; set; }
            public int CustomerId { get; set; }
            public Product Product { get; set; }
            public int ProductId { get; set; }
        }
        public class AppDbContext : DbContext
        {
            public static string ConnectionString = "data source=localhost\\SQLEXPRESS; initial catalog=CodeFirstCoreDemo; User Id=sa; Password=ayanami;";
            public static string ConnectionString2 = ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Order> Orders { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //optionsBuilder.UseSqlServer(ConnectionString);
                optionsBuilder.UseSqlServer("data source = localhost\\SQLEXPRESS; initial catalog = CodeFirstCoreDemo; User Id = sa; Password = ayanami;");
            }
        }

        static void Main(string[] args)
        {
            string cadena1 = AppDbContext.ConnectionString;
            string cadena2 = ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
            Console.WriteLine(cadena1);
            Console.WriteLine(cadena2);
        }
    }
}
