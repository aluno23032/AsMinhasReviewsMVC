using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsMinhasReviews.Data;
using AsMinhasReviews.Models;

namespace AsMinhasReviews.Controllers
{
    public class JogosController : Controller
    {
        /// <summary>
        /// Manipula os dados da base de dados
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Variável que contem os dados do servidor
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JogosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Jogos
        public async Task<IActionResult> Index(string id)
        {
            //Ordena a lista de jogos por rating ou data de lançamento
            switch (id)
            {
                case "Rating":
                    return View(await _context.Jogos.OrderByDescending(j => j.Rating).ToListAsync());
                case "Data":
                    return View(await _context.Jogos.OrderByDescending(j => j.DataLancamento).ToListAsync());
                default:
                    return View(await _context.Jogos.ToListAsync());
            }
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }
            //Inclui a lista de reviews referente ao jogo na vista detalhada desse mesmo jogo
            var jogos = await _context.Jogos
                .Include(j => j.ListaReviews)
                    .ThenInclude(r => r.Criador)
                .Where(j => j.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);

        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Capa,Plataformas,DataLancamento,Descricao,Rating")] Jogos jogo, IFormFile capaJogo, List<IFormFile> fotos)
        {
            //Formata o nome do jogo para letras minúsculas sem espaços
            jogo.NomeFormatado = jogo.Nome.Trim().ToLower();
            //Como o jogo não tem nenhuma review quando é criado, atribuir 0 a esse valor
            jogo.Rating = 0;
            //Se o utilizador não enviou uma capa, definir o valor do atributo como "semCapa.png"
            if (capaJogo == null)
            {
                jogo.Capa = "semCapa.png";
            }
            else
            {
                //Verificar se o ficheiro enviado para a capa é uma imagem
                if (!(capaJogo.ContentType == "image/png" || capaJogo.ContentType == "image/jpeg"))
                {
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    return View(jogo);
                }
                //Atribuir o nome da capa
                else
                {
                    string nomeFoto = (jogo.NomeFormatado + Path.GetExtension(capaJogo.FileName)).ToLower();
                    jogo.Capa = nomeFoto;
                }
            }
            if (ModelState.IsValid)
            {
                //Adicionar o jogo à base de dados
                _context.Add(jogo);
                await _context.SaveChangesAsync();
                //Guardar a imagem da capa enviada no servidor
                if (capaJogo != null)
                {
                    string nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                    nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                    if (!Directory.Exists(nomeLocalizacaoFicheiro))
                    {
                        Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                    }
                    //Nome do documento a guardar
                    string nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, jogo.Capa);
                    //Criar o objeto que vai manipular o ficheiro
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                    //Guardar no disco rígido
                    await capaJogo.CopyToAsync(stream);
                    int i = 0;
                    //Guardar as fotografias do jogo no servidor
                    foreach (IFormFile foto in fotos)
                    {
                        i++;
                        if (foto != null)
                        {
                            nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                            nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                            if (!Directory.Exists(nomeLocalizacaoFicheiro))
                            {
                                Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                            }
                            //Nome do documento a guardar
                            string nomeFoto = (jogo.NomeFormatado + i + Path.GetExtension(foto.FileName)).ToLower();
                            nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, nomeFoto);
                            //Criar o objeto que vai manipular o ficheiro
                            using var stream2 = new FileStream(nomeDaFoto, FileMode.Create);
                            //Guardar no disco rígido
                            await foto.CopyToAsync(stream2);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Processo igual à criação do jogo
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Capa,Plataformas,DataLancamento,Descricao")] Jogos jogo, IFormFile capaJogo, List<IFormFile> fotos)
        {
            jogo.NomeFormatado = jogo.Nome.Trim().ToLower();
            if (capaJogo == null)
            {
                jogo.Capa = "semCapa.png";
            }
            else
            {
                if (!(capaJogo.ContentType == "image/png" || capaJogo.ContentType == "image/jpeg"))
                {
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    return View(jogo);
                }
                else
                {
                    string nomeFoto = (jogo.NomeFormatado + Path.GetExtension(capaJogo.FileName)).ToLower();
                    jogo.Capa = nomeFoto;
                }
            }
            if (ModelState.IsValid)
            {
                _context.Update(jogo);
                await _context.SaveChangesAsync();
                if (capaJogo != null)
                {
                    string nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                    nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                    if (!Directory.Exists(nomeLocalizacaoFicheiro))
                    {
                        Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                    }
                    //Nome do documento a guardar
                    string nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, jogo.Capa);
                    //Criar o objeto que vai manipular o ficheiro
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                    //Guardar no disco rígido
                    await capaJogo.CopyToAsync(stream);
                    int i = 0;
                    foreach (IFormFile foto in fotos)
                    {
                        i++;
                        if (foto != null)
                        {
                            nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                            nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                            if (!Directory.Exists(nomeLocalizacaoFicheiro))
                            {
                                Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                            }
                            //Nome do documento a guardar
                            string nomeFoto = (jogo.NomeFormatado + i + Path.GetExtension(foto.FileName)).ToLower();
                            nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, nomeFoto);
                            //Criar o objeto que vai manipular o ficheiro
                            using var stream2 = new FileStream(nomeDaFoto, FileMode.Create);
                            //Guardar no disco rígido
                            await foto.CopyToAsync(stream2);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jogos'  is null.");
            }
            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos != null)
            {
                _context.Jogos.Remove(jogos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogosExists(int id)
        {
          return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
