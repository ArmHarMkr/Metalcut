using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Implementations
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        private AppDbContext _db;
        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(ProductEntity product)
        {
            var productFromDb = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productFromDb != null)
            {
                productFromDb.ProdDescription = product.ProdDescription;
                productFromDb.ProdName = product.ProdName;
                productFromDb.Price = product.Price;
            }
        }
    }
}
