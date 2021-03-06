using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Context _context;
        

        public ProductsController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include(x => x.Category).ToListAsync());    
        }

        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewProduct(Product product) 
        {
            if(ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }
		
		[HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            Product product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
          Product product = await _context.Products.FindAsync(id);

          _context.Products.Remove(product);

          await _context.SaveChangesAsync();

          return RedirectToAction(nameof(Index));
        }
    }
}              