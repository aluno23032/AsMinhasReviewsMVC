using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteReviews.Data;
using SiteReviews.Models;

namespace SiteReviews.Controllers
{
    public class FotografiasController : Controller
    {
        private readonly SiteReviewsContext _context;

        public FotografiasController(SiteReviewsContext context)
        {
            _context = context;
        }

        // GET: Fotografias
        public async Task<IActionResult> Index()
        {
            var siteReviewsContext = _context.Fotografias.Include(f => f.IdUtilizador);
            return View(await siteReviewsContext.ToListAsync());
        }

        // GET: Fotografias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fotografias == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias
                .Include(f => f.IdUtilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografias == null)
            {
                return NotFound();
            }

            return View(fotografias);
        }

        // GET: Fotografias/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id");
            return View();
        }

        // POST: Fotografias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtilizadorFK,Fotografia")] Fotografias fotografias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotografias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id", fotografias.UtilizadorFK);
            return View(fotografias);
        }

        // GET: Fotografias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fotografias == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias.FindAsync(id);
            if (fotografias == null)
            {
                return NotFound();
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id", fotografias.UtilizadorFK);
            return View(fotografias);
        }

        // POST: Fotografias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtilizadorFK,Fotografia")] Fotografias fotografias)
        {
            if (id != fotografias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotografias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografiasExists(fotografias.Id))
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
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id", fotografias.UtilizadorFK);
            return View(fotografias);
        }

        // GET: Fotografias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fotografias == null)
            {
                return NotFound();
            }

            var fotografias = await _context.Fotografias
                .Include(f => f.IdUtilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotografias == null)
            {
                return NotFound();
            }

            return View(fotografias);
        }

        // POST: Fotografias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fotografias == null)
            {
                return Problem("Entity set 'SiteReviewsContext.Fotografias'  is null.");
            }
            var fotografias = await _context.Fotografias.FindAsync(id);
            if (fotografias != null)
            {
                _context.Fotografias.Remove(fotografias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografiasExists(int id)
        {
          return _context.Fotografias.Any(e => e.Id == id);
        }
    }
}
