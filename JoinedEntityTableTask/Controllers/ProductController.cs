using JoinedEntityTableTask.Data;
using JoinedEntityTableTask.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JoinedEntityTableTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db) {
            _db = db;
        }

        public async Task<IActionResult> IndexAsync() {
            IEnumerable<Product> lastAddedProducts = await _db.Products.OrderByDescending(p => p.CreateDate)
                                                                       .Take(10)
                                                                       .ToListAsync();
            return View(lastAddedProducts);
        }


        //GET
        public async Task<IActionResult> Create() {
            await UpdateCategoryViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product) {
            if (ModelState.IsValid) {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            await UpdateCategoryViewBag();
            return View(product);
        }

        private async Task UpdateCategoryViewBag() {
            var categories = await _db.Categories.ToListAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
        }

        [HttpGet]
        public JsonResult CheckDuplicateProductName(string productName) {
            bool isDuplicate = _db.Products.Any(p => p.ProductName == productName);
            return Json(new { isDuplicate });
        }
    }
}
