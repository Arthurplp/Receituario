using Aplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domínio.Services;
using Domínio.Model;
using Aplicacao.Models;

namespace Aplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReceitaService _receitaService;

        public HomeController(ILogger<HomeController> logger, ReceitaService receitaService)
        {
            _logger = logger;
            _receitaService = receitaService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
            var receitas = await _receitaService.GetReceitas();
            var model = receitas == null ? new List<ReceitaViewModel>() : receitas.Select(r => new ReceitaViewModel
            {
                Id = r.Id.GetHashCode(), // Ajuste conforme necessário
                Nome = r.Nome,
                Descricao = r.Descricao
            }).ToList();
            if(model == null)
            {
                return View();
            }
            return View(model);
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
