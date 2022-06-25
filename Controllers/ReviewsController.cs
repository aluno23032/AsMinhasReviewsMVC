﻿using System;
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
    public class ReviewsController : Controller
    {
        private readonly SiteReviewsContext _context;

        public ReviewsController(SiteReviewsContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var siteReviewsContext = _context.Reviews.Include(r => r.IdObjeto).Include(r => r.IdUtilizador);
            return View(await siteReviewsContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.IdObjeto)
                .Include(r => r.IdUtilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["IdObjetoFK"] = new SelectList(_context.Set<Series>(), "Id", "Id");
            ViewData["CriadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Conteudo,CriadorFK,Rating,IdObjetoFK")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdObjetoFK"] = new SelectList(_context.Set<Series>(), "Id", "Id", reviews.IdObjetoFK);
            ViewData["CriadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id", reviews.CriadorFK);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["IdObjetoFK"] = new SelectList(_context.Set<Series>(), "Id", "Id", reviews.IdObjetoFK);
            ViewData["CriadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id", reviews.CriadorFK);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Conteudo,CriadorFK,Rating,IdObjetoFK")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
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
            ViewData["IdObjetoFK"] = new SelectList(_context.Set<Series>(), "Id", "Id", reviews.IdObjetoFK);
            ViewData["CriadorFK"] = new SelectList(_context.Set<Utilizadores>(), "Id", "Id", reviews.CriadorFK);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.IdObjeto)
                .Include(r => r.IdUtilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reviews == null)
            {
                return Problem("Entity set 'SiteReviewsContext.Reviews'  is null.");
            }
            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews != null)
            {
                _context.Reviews.Remove(reviews);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
          return _context.Reviews.Any(e => e.Id == id);
        }
    }
}