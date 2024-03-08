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
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        UserManager<AppUser> _userManager;
        //Site to add other Interfaces
        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IProductRepository Product { get; private set; }
        public IDeliveryRepository Delivery { get; private set; }
        public IChatRepository Chat { get; private set; }
        //---------

        public UnitOfWork(AppDbContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
            Department = new DepartmentRepository(_db);
            Employee = new EmployeeRepository(_db, _userManager);
            Product = new ProductRepository(_db);
            Delivery = new DeliveryRepository(_db);
            Chat = new ChatRepository(_db);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
