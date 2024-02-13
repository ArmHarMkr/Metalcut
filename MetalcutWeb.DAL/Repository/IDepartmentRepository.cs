using MetalcutWeb.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {        
        Task Update(Department department);
    }
}
