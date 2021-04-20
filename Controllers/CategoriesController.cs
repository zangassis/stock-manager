using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Controllers
{
  public class CategoriesController : Controller
    {
         private readonly Context _context;

         public CategoriesController(Context context)
         {
             _context = context;
         }

         public async Task<IActionResult> Index()
         {
             return View(await _context.Categories.ToListAsync());
         }

         [HttpGet]
         public IActionResult NewCategory()
         {
             return View();
         }

         [HttpPost]
         public async Task<IActionResult> NewCategory(Category category)
         {
             if(ModelState.IsValid)
             {
                 await _context.Categories.AddAsync(category);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(category);
         }

         [HttpGet]
         public async Task<IActionResult> UpdateCategory(int id)
         {
            return View(await _context.Categories.FindAsync(id));
         }

         [HttpPost]
         public async Task<IActionResult> UpdateCategory(Category category)
         {
             if(ModelState.IsValid)
             {
                 _context.Categories.Update(category);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(category);
         }

        [HttpPost]
         public async Task<IActionResult> DeleteCategory(int id)
         {
            Category category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
    }
}