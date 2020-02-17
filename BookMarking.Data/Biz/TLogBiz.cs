using BookMarking.Data.Dal.Repository;

namespace BookMarking.Data.Biz
{
    public class TLogBiz: TLogRepository
    {
        public static readonly TLogBiz Instance = new TLogBiz();
        private TLogBiz() : base()
        {
        }
        public TLogBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
