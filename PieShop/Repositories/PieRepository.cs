using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

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
            //var pieList = new List<Pie>();

            //using (IDbConnection con = new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            //{
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }

            //    pieList = con.Query<Pie>("GetAllPies").ToList();
            //}
            //return pieList;
        }

        public Pie GetPieById(int pieId)
        {
            return _dbContext.Pie.FirstOrDefault(p => p.PieId == pieId);
            //var pie = new Pie();
            //using (IDbConnection con = new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            //{
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }

            //    DynamicParameters parameter = new DynamicParameters();
            //    parameter.Add("@pieId", pieId);
            //    pie = con.Query<Pie>("GetPieById", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //}
            //return pie;
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

        public void DeletePie(Pie pie)
        {
            _dbContext.Pie.Remove(pie);
            _dbContext.SaveChanges();
        }
    }
}
