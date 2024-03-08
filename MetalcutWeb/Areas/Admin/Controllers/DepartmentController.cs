using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetalcutWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/{controller}")]
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public DepartmentController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AllDepartments()
        {

            var departmentFromDb = _unitOfWork.Department.GetAll();
            return View(departmentFromDb);
        }

        [HttpGet("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment()
        {
            return View();
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            if(ModelState.IsValid)
            {
                var employees = await _userManager.Users.Where(u => u.Id == department.Id).ToListAsync();
                await _unitOfWork.Department.Add(department);
                await _unitOfWork.Save();
                return RedirectToAction("AllDepartments", "Department");
            }
            return View();
        }

        [HttpGet("EditDepartment")]
        public async Task<IActionResult> EditDepartment(string? id)
        {
            var departmentFromDb = _unitOfWork.Department.Get(d => d.Id == id);
            if(departmentFromDb != null)
            {
                return View(departmentFromDb);
            }
            return NotFound();
        }

        [HttpPost("EditDepartment")]
        public async Task<IActionResult> EditDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                var employees = await _userManager.Users.Where(u => u.Id == department.Id).ToListAsync();
                await _unitOfWork.Department.Update(department);
                await _unitOfWork.Save();
                return RedirectToAction("AllDepartments", "Department");
            }
            return View();
        }

        [HttpPost("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(string? id)
        {
            var departmentFromDb = _unitOfWork.Department.Get(d => d.Id == id);
            if(departmentFromDb != null)
            {
                _unitOfWork.Department.Remove(departmentFromDb);
                await _unitOfWork.Save();
                return RedirectToAction("AllDepartments", "Department");
            }
            return NotFound();
        }
    }
}
