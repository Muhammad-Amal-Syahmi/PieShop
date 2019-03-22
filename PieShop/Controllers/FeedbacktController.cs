﻿using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class FeedbacktController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbacktController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}