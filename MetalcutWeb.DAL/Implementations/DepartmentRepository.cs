using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Implementations
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private AppDbContext _db;
        public DepartmentRepository(AppDbContext db) : base(db)
        {
            _db = db;   
        }

        public async Task Update(Department department)
        {
            var departmentFromDb = await _db.Departments.FirstOrDefaultAsync(d => d.Id == department.Id);
            if (departmentFromDb != null)
            {
                departmentFromDb.DepartmentName = department.DepartmentName;
            }
        }
    }
}
