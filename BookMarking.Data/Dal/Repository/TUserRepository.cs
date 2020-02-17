using BookMarking.Data.Base;

namespace BookMarking.Data.Dal.Domain
{
    public class TUserRepository:Respository,ITUserRepository
    {
        protected TUserRepository():base()
        {
        }
        protected TUserRepository(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
