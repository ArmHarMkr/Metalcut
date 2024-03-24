using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetalcutWeb.Controllers
{
    [Authorize]
    public class DeliveryController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public DeliveryController(AppDbContext db, IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpPost("RequestDelivery")]
        public async Task<IActionResult> RequestDelivery(string? id)
        {
            var productFromDb = _unitOfWork.Product.Get(p => p.Id == id);
            var currentUser = await _userManager.GetUserAsync(User);
            if (productFromDb != null || currentUser != null)
            {
                await _unitOfWork.Delivery.RequestDelivery(currentUser, productFromDb);
                await _unitOfWork.Save();
                return RedirectToAction("AllDeliveries");
            }
            return NotFound();
        }

        public async Task<IActionResult> AllDeliveries()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            IEnumerable<Delivery> deliveriesFromDb = _db.Deliveries.Include(d => d.DeliveryProduct).Where(p => p.RequestedUser == currentUser);
            return View(deliveriesFromDb);
        }

        [HttpPost("DeleteDeliveryRequest")]
        public async Task<IActionResult> DeleteDeliveryRequest(string? id)
        {
            Delivery deliveryFromDb = _unitOfWork.Delivery.Get(d => d.Id == id);
            _unitOfWork.Delivery.Remove(deliveryFromDb);
            await _unitOfWork.Save();
            return RedirectToAction("AllDeliveries");
        }
    }
}
