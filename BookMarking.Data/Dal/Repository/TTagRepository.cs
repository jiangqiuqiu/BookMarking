using BookMarking.Data.Base;
using BookMarking.Data.Dal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Dal.Repository
{
    public class TTagRepository : Respository, ITTagRepository
    {
        protected TTagRepository() : base()
        {
        }
        protected TTagRepository(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
