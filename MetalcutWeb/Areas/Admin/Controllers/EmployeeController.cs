using MetalcutWeb.Areas.Admin.ViewModels;
using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using MetalcutWeb.Domain.Roles;
using MetalcutWeb.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Protocol;
using SQLitePCL;

namespace MetalcutWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/{controller}")]
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<AppUser> _userManager;
        public EmployeeController(AppDbContext db, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            _db = db;
            _employeeService = employeeService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> AllUsers()
        {
            IEnumerable<AppUser> allUsers = await _userManager.Users.ToListAsync();
            return View(allUsers);
        }

        [HttpPost("GiveManagerRole")]
        public async Task<IActionResult> GiveManagerRole(string? id)
        {
            var userFromDb = _unitOfWork.Employee.Get(e => e.Id == id);
            if (userFromDb == null)
                return NotFound();
            await _employeeService.GiveManagerRole(userFromDb);
            return RedirectToAction("AllUsers");
        }


        [HttpPost("GiveEmployeeRole")]
        public async Task<IActionResult> GiveEmployeeRole(string? id)
        {
            var userFromDb = _unitOfWork.Employee.Get(e => e.Id == id);
            if(userFromDb != null)
            {
                await _employeeService.GiveEmployeeRole(userFromDb);
                return RedirectToAction("AllUsers");
            }
            return NotFound();
        }


        [HttpPost("GiveCustomerRole")]
        public async Task<IActionResult> GiveCustomerRole(string? id)
        {
            var userFromDb = _userManager.Users.Where(u => u.Id == id).ToList();
            if(userFromDb == null)
                return NotFound();
            await _employeeService.GiveCustomerRole(userFromDb[0]);
            return RedirectToAction("AllUsers");
        }

    }
}
