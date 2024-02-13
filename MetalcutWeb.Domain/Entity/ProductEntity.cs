using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Domain.Entity
{
    public class ProductEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public double Price { get; set; }
    }
}
