using Microsoft.AspNetCore.Mvc;

namespace stock_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly Context _context;
    }

    public ProductsController(Context context)
    {
        _context = context;
    }

    public async Task(ActionResult) Index()
    {
        return View(await _context.Products.Incude(x => x.Categtory).ToListAssynk();    
    }

    [HttpGet]
    public async Task<ActionResult> NewProduct()
    {
        viewData["Category"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name")
    }

    [HttpPost]
    public async Task<ActionResult> NewProduct(Product product) 
    {
        if(ModelState.IsValid)
        {
            await _context.Products.AddAsync();
            await _context.SaveChangesAsync();
            return RedirectToAction(named(Index));
        }

        return View(product);
    }

}              