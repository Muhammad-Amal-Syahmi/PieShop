using PieShop.DataAccess.Models;

namespace PieShop.Models
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
