using BookMarking.Data.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Biz
{
    public class TUrlBiz: TUrlRepository
    {
        public static readonly TUrlBiz Instance = new TUrlBiz();
        private TUrlBiz() : base()
        {
        }
        public TUrlBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
