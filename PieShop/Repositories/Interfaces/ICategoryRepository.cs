using System.Collections.Generic;

namespace PieShop.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
