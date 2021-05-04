using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace Stock_Manager.ViewComponents
{
    public class MovesViewComponent : ViewComponent
    {
        private readonly Context _context;

        public MovesViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.Moves.Where(x => x.ProductId == id).ToListAsync());
        }

    }
}