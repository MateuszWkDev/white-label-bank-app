namespace Mainframe.Data.DbServices
{
    public abstract class BaseDbService
    {
        protected BaseDbService(MainframeContext dbContext)
        {
            MainframeContext = dbContext;
        }

        protected MainframeContext MainframeContext { get; set; }
    }
}
