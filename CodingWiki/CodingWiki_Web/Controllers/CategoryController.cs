using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> objList = _dbContext.Categories.ToList();
            return View(objList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.CategoryName == null)
                {
                    await _dbContext.Categories.AddAsync(obj);
                }

                else
                {
                    _dbContext.Categories.Update(obj);
                }

                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }
    }
}
