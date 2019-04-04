using System.Collections.Generic;
using PieShop.DataAccess.Models;

namespace PieShop.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
