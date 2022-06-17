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
    public class RecipientesController : Controller
    {
        private readonly Context _context;

        public RecipientesController(Context context)
        {
            _context = context;
        }

        // GET: Recipientes
        public async Task<IActionResult> Index()
        {
              return _context.Recipiente != null ? 
                          View(await _context.Recipiente.ToListAsync()) :
                          Problem("Entity set 'Context.Recipiente'  is null.");
        }

        // GET: Recipientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipiente == null)
            {
                return NotFound();
            }

            var recipiente = await _context.Recipiente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipiente == null)
            {
                return NotFound();
            }

            return View(recipiente);
        }

        // GET: Recipientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Foto,Tamanho")] Recipiente recipiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipiente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipiente);
        }

        // GET: Recipientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipiente == null)
            {
                return NotFound();
            }

            var recipiente = await _context.Recipiente.FindAsync(id);
            if (recipiente == null)
            {
                return NotFound();
            }
            return View(recipiente);
        }

        // POST: Recipientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Foto,Tamanho")] Recipiente recipiente)
        {
            if (id != recipiente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipiente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipienteExists(recipiente.Id))
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
            return View(recipiente);
        }

        // GET: Recipientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipiente == null)
            {
                return NotFound();
            }

            var recipiente = await _context.Recipiente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipiente == null)
            {
                return NotFound();
            }

            return View(recipiente);
        }

        // POST: Recipientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipiente == null)
            {
                return Problem("Entity set 'Context.Recipiente'  is null.");
            }
            var recipiente = await _context.Recipiente.FindAsync(id);
            if (recipiente != null)
            {
                _context.Recipiente.Remove(recipiente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipienteExists(int id)
        {
          return (_context.Recipiente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
