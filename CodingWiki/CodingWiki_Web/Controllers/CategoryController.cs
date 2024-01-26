using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Book> objList = _dbContext.Books.Include(u => u.Publisher).ToList();
            foreach (var obj in objList)
            {
                ;
                _dbContext.Entry(obj).Reference(u => u.Publisher).Load();
            }
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

        public async Task<IActionResult> Playgound()
        {
            var bookTemp = _dbContext.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _dbContext.Books;
            decimal totalPrice = 0;

            foreach(var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Queryable()
        {
            IEnumerable<Book> books = _dbContext.Books;
            var filteredBooks = books.Where(b => b.Price > 500).ToList();

            IQueryable<Book> books2 = _dbContext.Books;
            var filteredBooks2 = books2.Where(b => b.Price > 500).ToList();

            return View(books2);
        }
    }
}
