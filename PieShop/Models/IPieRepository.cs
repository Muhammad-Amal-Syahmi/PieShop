using System.Collections.Generic;

namespace PieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPie();
        Pie GetPieById(int pieId);
    }
}
