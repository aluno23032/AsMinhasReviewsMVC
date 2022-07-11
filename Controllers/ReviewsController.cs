using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsMinhasReviews.Data;
using AsMinhasReviews.Models;

namespace AsMinhasReviews.Controllers
{
    public class ReviewsController : Controller
    {
        /// <summary>
        /// Manipula os dados da base de dados
        /// </summary>
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reviews.Include(r => r.Criador).Include(r => r.Jogo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }
            //Inclui informação sobre o criador da review e sobre o jogo para o qual a review é feita na vista detalhada dessa review
            var reviews = await _context.Reviews
                .Include(r => r.Criador)
                .Include(r => r.Jogo)
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
            //Mostra os jogos ordenados por nome na dropdown da vista de criação da review
            ViewData["JogoFK"] = new SelectList(_context.Jogos, "Id", "Nome").OrderBy(c => c.Text);
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataCriacao,Conteudo,Rating,CriadorFK,JogoFK")] Reviews review)
        {
            //Atribuir o id do criador e a data de criação da review à review em si
            var utilizador = _context.Utilizadores.FirstOrDefault(u => u.Nome == User.Identity.Name);
            review.CriadorFK = utilizador.Id;
            review.DataCriacao = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(review);
                //Atualizar o rating do jogo tendo em conta a review criada pelo utilizador
                var average = await _context.Reviews.Where(r => r.JogoFK == review.JogoFK).AverageAsync(r => r.Rating);
                Jogos j = await _context.Jogos.FirstOrDefaultAsync(j => j.Id == review.JogoFK);
                j.Rating = (decimal)average;
                await _context.SaveChangesAsync();
                //Determinar a página para a qual o utilizador será redirecionado
                var route = new RouteValueDictionary {
                    { "id", review.Id } };
                return RedirectToAction(nameof(Details), nameof(Reviews), route);
            }
            return View(review);
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
            ViewData["CriadorFK"] = new SelectList(_context.Utilizadores, "Id", "Nome", reviews.CriadorFK);
            ViewData["JogoFK"] = new SelectList(_context.Jogos, "Id", "Capa", reviews.JogoFK);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataCriacao,Conteudo,Rating,CriadorFK,JogoFK")] Reviews review)
        {
            //Determinar a página para a qual o utilizador será redirecionado
            var route = new RouteValueDictionary {
                    { "id", review.Id } };
            if (id != review.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(review);
                _context.SaveChanges();
                //Atualizar o rating do jogo tendo em conta a review criada pelo utilizador
                var average = await _context.Reviews.Where(r => r.JogoFK == review.JogoFK).AverageAsync(r => r.Rating);
                Jogos j = await _context.Jogos.FirstOrDefaultAsync(j => j.Id == review.JogoFK);
                j.Rating = (decimal)average;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), nameof(Reviews), route);
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }
            //Inclui informação sobre o criador da review e sobre o jogo para o qual a review é feita na vista detalhada dessa review
            var reviews = await _context.Reviews
                .Include(r => r.Criador)
                .Include(r => r.Jogo)
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
                return Problem("Entity set 'ApplicationDbContext.Reviews'  is null.");
            }
            var review = await _context.Reviews.FindAsync(id);
            //Determinar a página para a qual o utilizador será redirecionado
            var route = new RouteValueDictionary {
                { "id", review.JogoFK } };
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
            //Atualizar o rating do jogo tendo em conta a review criada pelo utilizador
            var average = await _context.Reviews.Where(r => r.JogoFK == review.JogoFK).AverageAsync(r => r.Rating);
            Jogos j = await _context.Jogos.FirstOrDefaultAsync(j => j.Id == review.JogoFK);
            j.Rating = (decimal)average;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), nameof(Jogos),route);
        }

        private bool ReviewsExists(int id)
        {
          return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
