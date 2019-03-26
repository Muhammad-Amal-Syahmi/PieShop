﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PieManagementController : Controller
    {
        private readonly IPieRepository _pieRepository;
        //private readonly ICategoryRepository _categoryRepository;

        public PieManagementController(IPieRepository pieRepository /*, ICategoryRepository categoryRepository */)
        {
            _pieRepository = pieRepository;
            //_categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var pies = _pieRepository.GetAllPie().OrderBy(p => p.Id);
            return View(pies);
        }

        //public IActionResult AddPie()
        //{
        //    var categories = _categoryRepository.Categories;
        //    var pieAddEditViewModel = new PieAddEditViewModel
        //    {
        //        Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
        //        CategoryId = categories.FirstOrDefault().CategoryId
        //    };
        //    return View(pieAddEditViewModel);
        //}

        //[HttpPost]
        //public IActionResult AddPie(PieEditViewModel pieEditViewModel)
        //{
        //    //Basic validation
        //    if (ModelState.IsValid)
        //    {
        //        _pieRepository.CreatePie(pieEditViewModel.Pie);
        //        return RedirectToAction("Index");
        //    }
        //    return View(pieEditViewModel);
        //}

        //public IActionResult EditPie(int pieId)
        //{
        //    var categories = _categoryRepository.Categories;

        //    var pie = _pieRepository.Pies.FirstOrDefault(p => p.PieId == pieId);

        //    var pieEditViewModel = new PieEditViewModel
        //    {
        //        Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
        //        Pie = pie,
        //        CategoryId = pie.CategoryId
        //    };

        //    var item = pieEditViewModel.Categories.FirstOrDefault(c => c.Value == pie.CategoryId.ToString());
        //    item.Selected = true;

        //    return View(pieEditViewModel);
        //}

        //[HttpPost]
        //public IActionResult EditPie(PieEditViewModel pieEditViewModel)
        //{
        //    pieEditViewModel.Pie.CategoryId = pieEditViewModel.CategoryId;

        //    if (ModelState.IsValid)
        //    {
        //        _pieRepository.UpdatePie(pieEditViewModel.Pie);
        //        return RedirectToAction("Index");
        //    }
        //    return View(pieEditViewModel);
        //}

        //[HttpPost]
        //public IActionResult DeletePie(string pieId)
        //{
        //    return View();
        //}

    }
}