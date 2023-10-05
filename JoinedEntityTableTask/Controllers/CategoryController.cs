using JoinedEntityTableTask.Data;
using JoinedEntityTableTask.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JoinedEntityTableTask.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }

        public async Task<IActionResult> Index() {
            IEnumerable<Category> categotyList = await _db.Categories.ToListAsync();
            return View(categotyList);
        }

        //GET
        public IActionResult Create() {
            return View();
        }

        /// <summary>
        /// Создаем новую категорию, с допольнительной проверкой на стороне сервера на уникальность CategoryName.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category) {
            if (ModelState.IsValid) {

                if (_db.Categories.Any(x => x.CategoryName == category.CategoryName)) {
                    ModelState.AddModelError("CategoryName", "Category name must be unique.");
                    return View(category);
                }

                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

    }
}
