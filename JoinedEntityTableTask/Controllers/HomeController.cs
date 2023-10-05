using JoinedEntityTableTask.Data;
using JoinedEntityTableTask.Models;
using JoinedEntityTableTask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JoinedEntityTableTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db) {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index() {
            return View(GetJoinedTable());
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<ProductCategoryViewModel> GetJoinedTable() {
            return _db.Products.Join(
                _db.Categories,
                prod => prod.CategoryId,
                cat => cat.CategoryId,
                (prod, cat) => new ProductCategoryViewModel {
                    ProductName = prod.Name,
                    CategoryName = cat.CategoryName
                }).ToList();
        }
    }
}