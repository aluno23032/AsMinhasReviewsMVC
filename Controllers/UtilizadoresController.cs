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
    public class UtilizadoresController : Controller
    {
        private readonly SiteReviewsContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public UtilizadoresController(
           SiteReviewsContext context,
           IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Utilizadores.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUtilizador,Email,DataNascimento,Fotografia,UserID,admin")] Utilizadores utilizadores, IFormFile fotoUser)
        {                
                if (fotoUser == null)
                {
                    utilizadores.Fotografia = "noUser.png";
                }
                else
                {
                    if (!(fotoUser.ContentType == "image/png" || fotoUser.ContentType == "image/jpeg"))
                    {
                        ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                        return View(utilizadores);
                    }
                    else {
                        Guid g = Guid.NewGuid();
                        string nomeFoto = utilizadores.Id + "_" + g.ToString();
                        string extensaoFoto = Path.GetExtension(fotoUser.FileName).ToLower();
                        nomeFoto += extensaoFoto;
                        utilizadores.Fotografia = nomeFoto;
                }
                }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(utilizadores);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro com a operação de guardar os dados do utilizador " + utilizadores.NomeUtilizador);
                    return View(utilizadores);
                }
                if (fotoUser != null)
                {
                    string nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                    nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                    if (!Directory.Exists(nomeLocalizacaoFicheiro))
                    {
                        Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                    }
                    string nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, utilizadores.Fotografia);
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                    await fotoUser.CopyToAsync(stream);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores == null)
            {
                return NotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUtilizador,Email,DataNascimento,Fotografia,UserID")] Utilizadores utilizadores)
        {
            if (id != utilizadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizadores.Id))
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
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinario = await _context.Utilizadores.FindAsync(id);
            _context.Utilizadores.Remove(veterinario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
          return _context.Utilizadores.Any(e => e.Id == id);
        }
    }
}
