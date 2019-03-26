using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AWS_POSTGREQL_TRIALContext _dbContext;

        public PieRepository(AWS_POSTGREQL_TRIALContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pie> GetAllPie()
        {
            return _dbContext.Pie;
        }

        public Pie GetPieById(int pieId)
        {
            return _dbContext.Pie.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _dbContext.Pie.Where(p => p.IsPieOfTheWeek);
            }
        }

        public void CreatePie(Pie pie)
        {
            _dbContext.Pie.Add(pie);
            _dbContext.SaveChanges();
        }

        public void UpdatePie(Pie pie)
        {
            _dbContext.Pie.Update(pie);
            _dbContext.SaveChanges();
        }
    }
}
