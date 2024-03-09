using MetalcutWeb.Areas.Manager.ViewModel;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Construction;
using SQLitePCL;

namespace MetalcutWeb.Areas.Manager.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    [Route("ManagerProduct/{controller}")]
    [Area("Manager")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            IEnumerable<ProductEntity> productFromDb = _unitOfWork.Product.GetAll().ToList();
            return View(productFromDb);
        }

        [HttpGet("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Product.Add(productEntity);
                await _unitOfWork.Save();
                return RedirectToAction("AllProducts");
            }
            return View();
        }



        [HttpGet("EditProduct")]
        public async Task<IActionResult> EditProduct(string? id)
        {
            if (id != null)
            {
                var productFromDb = _unitOfWork.Product.Get(p => p.Id == id);
                if (productFromDb != null)
                    return View(productFromDb);
            }
            return NotFound();
        }

        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct(ProductEntity product)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Product.Update(product);
                await _unitOfWork.Save();
                return RedirectToAction("AllProducts");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string? id)
        {
            if (id != null)
            {
                var productFromDb = _unitOfWork.Product.Get(p => p.Id == id);
                _unitOfWork.Product.Remove(productFromDb);
                await _unitOfWork.Save();
                return RedirectToAction("AllProducts");

            }
            return NotFound();
        }

    }
}

