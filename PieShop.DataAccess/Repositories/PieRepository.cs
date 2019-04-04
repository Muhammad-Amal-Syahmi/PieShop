using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using PieShop.DataAccess.Models;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        //private readonly AWS_POSTGREQL_TRIALContext _dbContext;
        private readonly IConfiguration _configuration;

        public PieRepository(/*AWS_POSTGREQL_TRIALContext dbContext,*/ IConfiguration configuration)
        {
            //_dbContext = dbContext;
            _configuration = configuration;
        }

        public IEnumerable<Pie> GetAllPie()
        {
            var pieList = new List<Pie>();

            var query = "SELECT * FROM Pie";

            using (var con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                pieList = con.Query<Pie>(query).ToList();
            }
            return pieList;

            //LINQ
            //return _dbContext.Pie;
        }

        public Pie GetPieById(int pieId)
        {
            var pie = new Pie();

            var query = "SELECT * FROM Pie WHERE pie_id = " + pieId;

            using (var con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                pie = con.QueryFirstOrDefault<Pie>(query);
            }
            return pie;

            //LINQ
            //return _dbContext.Pie.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                var pieList = new List<Pie>();

                var query = "SELECT * FROM Pie WHERE  is_pie_of_the_week";

                using (var con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    pieList = con.Query<Pie>(query).ToList();
                }
                return pieList;

                //LINQ
                //return _dbContext.Pie.Where(p => p.IsPieOfTheWeek);
            }
        }

        public void CreatePie(Pie pie)
        {
            var query = "Insert into Pie ( name, " +
                "short_description, " +
                "long_description, " +
                "price, " +
                "image_url, " +
                "image_thumbnail_url, " +
                "is_in_stock, " +
                "is_pie_of_the_week, " +
                "category_id) " +
                "values (@name, " +
                "@short_description, " +
                "@long_description, " +
                "@price, " +
                "@image_url, " +
                "@image_thumbnail_url, " +
                "@is_in_stock, " +
                "@is_pie_of_the_week, " +
                "@category_id)";

            using (var con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Execute(query,
                    new
                    {
                        pie.name,
                        pie.short_description,
                        pie.long_description,
                        pie.price,
                        pie.image_url,
                        pie.image_thumbnail_url,
                        pie.is_in_stock,
                        pie.is_pie_of_the_week,
                        pie.category_id
                    });
            }

            //LINQ
            //_dbContext.Pie.Add(pie);
            //_dbContext.SaveChanges();
        }

        public void UpdatePie(Pie pie)
        {
            var query = "UPDATE Pie SET name= @name, " +
                "short_description= @short_description, " +
                "long_description= @long_description, " +
                "price= @price, " +
                "image_url= @image_url, " +
                "image_thumbnail_url= @image_thumbnail_url, " +
                "is_in_stock= @is_in_stock, " +
                "is_pie_of_the_week= @is_pie_of_the_week, " +
                "category_id= @category_id " +
                "WHERE pie_id = @pie_id";

            using (var con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Execute(query,
                    new
                    {
                        pie.name,
                        pie.short_description,
                        pie.long_description,
                        pie.price,
                        pie.image_url,
                        pie.image_thumbnail_url,
                        pie.is_in_stock,
                        pie.is_pie_of_the_week,
                        pie.category_id,
                        pie.pie_id
                    });
            }

            //LINQ
            //_dbContext.Pie.Update(pie);
            //_dbContext.SaveChanges();
        }

        public void DeletePie(Pie pie)
        {
            var query = "DELETE FROM  Pie WHERE pie_id = @pie_id";

            using (var con = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Execute(query, new { pie.pie_id });
            }

            //LINQ
            //_dbContext.Pie.Remove(pie);
            //_dbContext.SaveChanges();
        }
    }
}
