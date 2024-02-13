using MetalcutWeb.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Repository
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task Update(ProductEntity product);
    }
}
