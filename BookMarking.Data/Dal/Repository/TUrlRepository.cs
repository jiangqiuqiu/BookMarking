using BookMarking.Data.Base;
using BookMarking.Data.Dal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Dal.Repository
{
    public class TUrlRepository : Respository, ITUrlRepository
    {
        protected TUrlRepository() : base()
        {
        }
        protected TUrlRepository(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
