using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Controllers
{
    public class MovesController : Controller
    {
        private readonly Context _Context;

        public MovesController(Context context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult NewMove(int productId)
        {
            Move move = new Move 
            { Id = productId };
            return View(move);
        }

        [HttpPost]        
        public async Task<IActionResult> NewMove(Move move)
        {
            move.MoveDate = DateTime.Now;

            move.MoveDate.ToString();

            if(ModelState.IsValid)
            {
                await _Context.Moves.AddAsync(move);
                await _Context.SaveChangesAsync();
                return RedirectToAction("ProductDetails", "Products", new { id = move.ProductId });
            }

            return View(move);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMove(int id)
        {
            Move move = await _Context.Moves.FindAsync(id);
            return View(move);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMove(Move move)
        {
            if(ModelState.IsValid)
            {
                _Context.Moves.Update(move);
                await _Context.SaveChangesAsync();
                return RedirectToAction("ProductDetails", "Products", new { id = move.ProductId });
            }

            return View(move);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMove(int id)
        {
            Move move = await _Context.Moves.FindAsync(id);
            _Context.Moves.Remove(move);
            await _Context.SaveChangesAsync();
            return RedirectToAction("ProductDetails", "Products", new { id = move.ProductId });
        }
    }
}