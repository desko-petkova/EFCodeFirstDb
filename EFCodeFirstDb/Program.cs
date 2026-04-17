using EFCodeFirstDb.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDb;TrustServerCertificate=False;Integrated Security=True;")
    .Options;

            using var db = new AppDbContext(options);

            //var products = db.Products.ToList();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Id+". "+product.Name);
            //}

            //var productsNamesPrice = db.Products.Select(
            //    p => new
            //    {
            //        ProductName = p.Name,
            //        ProductPrice = p.Price

            //    }).ToList();

            //foreach(var product in productsNamesPrice)
            //{
            //    Console.WriteLine(product.ProductName+" - "+product.ProductPrice);
            //}

            var productCategory = db.Products.Select(
                p => new
                {
                    ProductName = p.Name,
                    Category = p.Category.Name

                }).ToList();

            foreach (var product in productCategory)
            {
                Console.WriteLine(product.ProductName+ " - "+product.Category);
            }



        }
    }
}
