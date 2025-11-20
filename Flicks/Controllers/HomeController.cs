using Flicks.Models;
using Microsoft.AspNetCore.Mvc;
using ProyectoDSMGen.ApplicationCore.CEN.Flicks;
using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.Infraestructure.Repository.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using System.Diagnostics;

namespace Flicks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IPeliculaRepository peliculaRepo = new PeliculaRepository();
            PeliculaCEN peliculaCEN = new PeliculaCEN(peliculaRepo);
            IList<PeliculaEN> listaPel = peliculaCEN.ReadAll(0, -1);
            return View(listaPel);
        }

        public IActionResult Privacy()
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
