using System.Collections.Generic;

namespace PieShop.Models
{
    public interface IPieRepository
    {
        Pie GetPieById(int pieId);
        IEnumerable<Pie> GetAllPie();
        IEnumerable<Pie> PiesOfTheWeek { get; }

    }
}
