using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PieShop.DataAccess.Models;

namespace PieShop.ViewModels
{
    public class PieAddEditViewModel
    {
        public Pie Pie { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
