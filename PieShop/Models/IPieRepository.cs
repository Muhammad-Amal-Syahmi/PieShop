using System.Collections.Generic;

namespace Piehop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPie();
        Pie GetPieById(int pieId);
    }
}
