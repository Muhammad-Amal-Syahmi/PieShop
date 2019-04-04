using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public ViewResult Index()
        {
            var allPies = _pieRepository.GetAllPie();

            return View(allPies);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
    }
}