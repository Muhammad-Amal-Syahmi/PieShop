using System.Collections.Generic;
using PieShop.DataAccess.Models;

namespace PieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
        //public string Title { get; set; }
        //public List<Pie> Pie { get; set; }
    }
}
