using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productdb = _context.Products.FirstOrDefault(x=>x.Id == product.Id);
            if(productdb != null)
            {
                productdb.Name = product.Name;
                productdb.Description = product.Description;
                productdb.Price = product.Price;
                if(product.ImageUrl != null)
                {
                    productdb.ImageUrl = product.ImageUrl;
                }
            }    
        }
    }
}
