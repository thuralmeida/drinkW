using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using drinkW.Models;

namespace drinkW.Controllers
{
    public class ConsumosController : Controller
    {
        private readonly Context _context;

        public ConsumosController(Context context)
        {
            _context = context;
        }

        // GET: Consumos
        public async Task<IActionResult> Index()
        {
              return _context.Consumo != null ? 
                          View(await _context.Consumo.ToListAsync()) :
                          Problem("Entity set 'Context.Consumo'  is null.");
        }

        // GET: Consumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consumo == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // GET: Consumos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsumo,RecipienteConsumo,TamanhoConsumo")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumo);
        }

        // GET: Consumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consumo == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            return View(consumo);
        }

        // POST: Consumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataConsumo,RecipienteConsumo,TamanhoConsumo")] Consumo consumo)
        {
            if (id != consumo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consumo);
        }

        // GET: Consumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consumo == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: Consumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consumo == null)
            {
                return Problem("Entity set 'Context.Consumo'  is null.");
            }
            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumo.Remove(consumo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoExists(int id)
        {
          return (_context.Consumo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
