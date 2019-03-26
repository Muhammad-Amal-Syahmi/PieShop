using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PieShop.Models;
using PieShop.Repositories.Interfaces;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PieManagementController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieManagementController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var pies = _pieRepository.GetAllPie().OrderBy(p => p.PieId);
            return View(pies);
        }

        public IActionResult AddPie()
        {
            var categories = _categoryRepository.Categories;
            var pieAddEditViewModel = new PieAddEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().CategoryId
            };
            return View(pieAddEditViewModel);
        }

        [HttpPost]
        public IActionResult AddPie(PieAddEditViewModel pieAddEditViewModel)
        {
            //Basic validation
            if (ModelState.IsValid)
            {
                pieAddEditViewModel.Pie.CategoryId = pieAddEditViewModel.CategoryId;
                _pieRepository.CreatePie(pieAddEditViewModel.Pie);
                return RedirectToAction("Index");
            }
            var categories = _categoryRepository.Categories;
            pieAddEditViewModel.Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList();
            return View(pieAddEditViewModel);

        }

        public IActionResult EditPie(int pieId)
        {
            var categories = _categoryRepository.Categories;

            var pie = _pieRepository.GetAllPie().FirstOrDefault(p => p.PieId == pieId);

            var pieAddEditViewModel = new PieAddEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Pie = pie,
                CategoryId = pie.CategoryId
            };

            var item = pieAddEditViewModel.Categories.FirstOrDefault(c => c.Value == pie.CategoryId.ToString());
            item.Selected = true;

            return View(pieAddEditViewModel);
        }

        [HttpPost]
        public IActionResult EditPie(PieAddEditViewModel pieAddEditViewModel)
        {
            pieAddEditViewModel.Pie.CategoryId = pieAddEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _pieRepository.UpdatePie(pieAddEditViewModel.Pie);
                return RedirectToAction("Index");
            }
            return View(pieAddEditViewModel);
        }

        //[HttpPost]
        //public IActionResult DeletePie(string pieId)
        //{
        //    return View();
        //}

    }
}