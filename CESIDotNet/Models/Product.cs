using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESICommerce.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

      /*  public Product(string name, string description, decimal price, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public Product(int productID, string name, string description, decimal price, string category)
        {
            ProductID = productID;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }*/
    }

    public interface IProductRepository {
        IQueryable<Product> Products { get; }
    }

    public class FalseProductRepository : IProductRepository
    {
        //   IQueryable<Product> IProductRepository.Products => new List<Product>().Add(new Product(1, "Kayak", "Mon beau kayak", 999, "Aquatique"));
        /*      IQueryable<Product> IProductRepository.Products => new List<Product>() {
                 new Product("Kayak", "Mon beau kayak", 999, "Aquatique"),
                 new Product("Bateau", "Mon beau bato", 123456, "Aquatique"),
                 new Product("Wlh", "Dit wallah", 3, "Religion"),
              }.AsQueryable<Product>();*/

        IQueryable<Product> IProductRepository.Products => null;
    }

    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> Products => this.context.Products;
    }

}
