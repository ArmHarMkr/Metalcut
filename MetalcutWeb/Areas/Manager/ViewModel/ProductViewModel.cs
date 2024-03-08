using MetalcutWeb.Domain.Entity;

namespace MetalcutWeb.Areas.Manager.ViewModel
{
    public class ProductViewModel
    {
        public ProductEntity ProductEntity { get; set; }
        public List<Department> Departments { get; set; }
    }
}
