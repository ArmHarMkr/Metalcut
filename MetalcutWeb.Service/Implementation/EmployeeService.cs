using MetalcutWeb.DAL.Data;
using MetalcutWeb.Domain.Entity;
using MetalcutWeb.Domain.Roles;
using MetalcutWeb.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public EmployeeService(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


        public async Task GiveManagerRole(AppUser appUser)
        {
            await _userManager.RemoveFromRoleAsync(appUser, SD.Role_Employee);
            await _userManager.RemoveFromRoleAsync(appUser, SD.Role_Customer);
            await _userManager.AddToRoleAsync(appUser, SD.Role_Manager);
            
        }
        public async Task GiveEmployeeRole(AppUser appUser)
        {
            await _userManager.RemoveFromRoleAsync(appUser, SD.Role_Customer);
            await _userManager.RemoveFromRoleAsync(appUser, SD.Role_Manager);
            await _userManager.AddToRoleAsync(appUser, SD.Role_Employee);
        }

        public async Task GiveCustomerRole(AppUser appUser)
        {
            await _userManager.RemoveFromRoleAsync(appUser, SD.Role_Employee);
            await _userManager.RemoveFromRoleAsync(appUser, SD.Role_Manager);
            await _userManager.AddToRoleAsync(appUser, SD.Role_Customer);
        }
    }
}