using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Implementations
{
    public class EmployeeRepository : Repository<AppUser>, IEmployeeRepository
    {
        private AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public EmployeeRepository(AppDbContext db, UserManager<AppUser> userManager) : base(db)
        {
            _userManager = userManager;
            _db = db;
        }

    }
}
