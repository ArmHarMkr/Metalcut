using MetalcutWeb.Domain.Entity;

namespace MetalcutWeb.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {
        public AppUser EmployeeUser { get; set; }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }
    }
}
