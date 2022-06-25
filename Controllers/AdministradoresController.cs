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
    public class AdministradoresController : Controller
    {
        private readonly SiteReviewsContext _context;

        public AdministradoresController(SiteReviewsContext context)
        {
            _context = context;
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Administradores.ToListAsync());
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administradores = await _context.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administradores == null)
            {
                return NotFound();
            }

            return View(administradores);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUtilizador,Email,DataNascimento,Fotografia")] Administradores administradores, IFormFile fotoAdmin)
        {
            if (fotoAdmin == null)
            {
                administradores.Fotografia = "noAdmin.png";
            }
            else
            {
                if (!(fotoAdmin.ContentType == "image/png" || fotoAdmin.ContentType == "image/jpeg"))
                {
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    return View(administradores);
                }
                else
                {
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(administradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administradores);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administradores = await _context.Administradores.FindAsync(id);
            if (administradores == null)
            {
                return NotFound();
            }
            return View(administradores);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUtilizador,Email,DataNascimento,Fotografia")] Administradores administradores)
        {
            if (id != administradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradoresExists(administradores.Id))
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
            return View(administradores);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administradores = await _context.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administradores == null)
            {
                return NotFound();
            }

            return View(administradores);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Administradores == null)
            {
                return Problem("Entity set 'SiteReviewsContext.Administradores'  is null.");
            }
            var administradores = await _context.Administradores.FindAsync(id);
            if (administradores != null)
            {
                _context.Administradores.Remove(administradores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradoresExists(int id)
        {
          return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
