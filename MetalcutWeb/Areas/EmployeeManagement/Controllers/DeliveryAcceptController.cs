using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetalcutWeb.Areas.EmployeeManagement.Controllers
{
    [Authorize(Roles = "Admin, Employee, Manager")]
    [Route("EmployeeManagement/{controller}")]
    [Area("EmployeeManagement")]
    public class DeliveryAcceptController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public DeliveryAcceptController(AppDbContext db, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> AllDeliveries()
        {
            /*            var deliveriesFromDb = _unitOfWork.Delivery.GetAll();*/
            IEnumerable<Delivery> deliveriesFromDb = _db.Deliveries
                .Include(d => d.DeliveryProduct)
                .Include(d => d.RequestedUser)
                .ToList();
            return View(deliveriesFromDb);
        }

        [HttpPost("AcceptDelivery")]
        public async Task<IActionResult> AcceptDelivery(string? id)
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            Delivery deliveryFromDb = await _db.Deliveries
                                        .Include(d => d.AcceptedUser)
                                        .Include(d => d.RequestedUser)
                                        .FirstOrDefaultAsync(d => d.Id == id);
            await _unitOfWork.Delivery.AcceptDelivery(currentUser, deliveryFromDb);
            var deliveryList = _db.Deliveries
                .Include(d => d.DeliveryProduct)
                .Include(d => d.AcceptedUser)
                .Include(d => d.RequestedUser)
                .ToList();
            return View("AllDeliveries", deliveryList);
        }


    }
}
