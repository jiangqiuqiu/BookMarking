using BookMarking.Data.Dal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Biz
{
    public class TUserBiz: TUserRepository
    {
        public static readonly TUserBiz Instance = new TUserBiz();
        private TUserBiz():base()
        {
        }
        public TUserBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
