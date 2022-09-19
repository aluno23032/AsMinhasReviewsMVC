using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace AsMinhasReviews.Controllers
{
    public class DetalhesController : Controller
    {
        private readonly ILogger<DetalhesController> _logger;
        public DetalhesController(ILogger<DetalhesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}