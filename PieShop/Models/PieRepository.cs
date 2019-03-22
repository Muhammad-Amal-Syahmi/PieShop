﻿using System.Collections.Generic;
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
            return _dbContext.Pie.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
