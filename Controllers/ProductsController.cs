using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ActionResult> Index()
        {
            return View(await _context.Products.Include(x => x.Categtory).ToListAssynk());    
        }

        [HttpGet]
        public async Task<ActionResult> NewProduct()
        {
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
        }

        [HttpPost]
        public async Task<ActionResult> NewProduct(Product product) 
        {
            if(ModelState.IsValid)
            {
                await _context.Products.AddAsync();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }
    }
}              