using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        //public IActionResult Index()
        //{
        //    var Pie = _pieRepository.GetAllPie().OrderBy(p => p.Name);

        //    var homeViewModel = new HomeViewModel()
        //    {
        //        Title = "Welcome to Pie Shop",
        //        Pie = Pie.ToList()
        //    };
        //    return View(homeViewModel);
        //}

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };

            return View(homeViewModel);
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