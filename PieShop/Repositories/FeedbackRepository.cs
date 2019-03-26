namespace PieShop.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AWS_POSTGREQL_TRIALContext _dbContext;

        public FeedbackRepository(AWS_POSTGREQL_TRIALContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _dbContext.Feedback.Add(feedback);
            _dbContext.SaveChanges();
        }
    }
}
