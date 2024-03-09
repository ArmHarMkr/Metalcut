using MetalcutWeb.Domain.Entity;
using Microsoft.Build.ObjectModelRemoting;

namespace MetalcutWeb.Areas.Manager.ViewModel
{
    public class ProductViewModel
    {
        public ProductEntity ProductEntity { get; set; }
        public List<Department> Departments { get; set; }
    }
}
