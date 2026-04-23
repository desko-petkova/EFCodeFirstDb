using EFCodeFirstDb.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(
  "Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDb;TrustServerCertificate=False;Integrated Security=True;")
    .Options;

            using var db = new AppDbContext(options);

            //var products = db.Products.ToList();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Id + ". " + product.Name);
            //}

            var productsNamesPrice = db.Products.Select(
                p => new
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price,
                    PriceWithVat = p.Price * 1.2m

                }).ToList();

            foreach (var product in productsNamesPrice)
            {
                Console.WriteLine(product.ProductName + " - " + product.ProductPrice+" price with VAT: "+
                    product.PriceWithVat);
            }


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

            // Products price > 100

            var productsOver100 = db.Products.Where(p => p.Price>100 ).ToList();

            // Product's names starts with letter L

            var productsStartsWithL = db.Products.Where(p=>p.Name.StartsWith("L")).ToList();

            // OrderBy ASC price
            var priceOrder = db.Products.OrderByDescending(p => p.Price).Take(3).ToList();

            // Count

            var productsCount = db.Products.Count(p => p.Price > 100);

            // Max and Min price

            var minPrice = db.Products.Min(p => p.Price);
            var maxPrice = db.Products.Max(p => p.Price);

            // Count products in each category
            var categoriesProductsCount = db.Categories.Select(c => new
            {
                categoryName = c.Name,
                productsCount = c.Products.Count()
            }).ToArray();

            //  first product with price over 100

            var firstProduct = db.Products.FirstOrDefault(p => p.Price > 100);




        }
    }
}
