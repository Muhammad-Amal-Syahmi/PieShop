using System.Collections.Generic;
using PieShop.DataAccess.Models;

namespace PieShop.Models
{
    public interface IPieRepository
    {
        Pie GetPieById(int pieId);
        IEnumerable<Pie> GetAllPie();
        IEnumerable<Pie> PiesOfTheWeek { get; }
        void CreatePie(Pie pie);
        void UpdatePie(Pie pie);
        void DeletePie(Pie pie);
    }
}
