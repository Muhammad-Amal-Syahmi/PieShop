using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Pie Overview";

            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);
            return View(pies);
        }
    }
}