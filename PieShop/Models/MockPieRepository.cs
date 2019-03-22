using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private List<Pie> _pies;

        public MockPieRepository()
        {
            if (_pies == null)
            {
                InitializePies();
            }
        }

        private void InitializePies()
        {
            _pies = new List<Pie>
            {
                new Pie {Id=1, Name="ApplePie", Price= 12.95M, ShortDescription="", LongDescription=""},
                new Pie {Id=2, Name="Cheese Pie", Price= 18.95M, ShortDescription="", LongDescription=""},
                new Pie {Id=3, Name= "Blueberry Pie", Price= 18.95M, ShortDescription="", LongDescription=""},
                new Pie {Id=4, Name= "Cherry Pie", Price=15.95M, ShortDescription="", LongDescription=""},
            };
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
