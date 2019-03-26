using System.Collections.Generic;
using PieShop.Models;
using PieShop.Repositories.Interfaces;

namespace PieShop.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly AWS_POSTGREQL_TRIALContext _dbContext;

        public CategoryRepository(AWS_POSTGREQL_TRIALContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Category> Categories => _dbContext.Category;
    }

}
