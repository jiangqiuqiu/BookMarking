using BookMarking.Data.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Biz
{
    public class TTagBiz: TTagRepository
    {
        public static readonly TTagBiz Instance = new TTagBiz();
        private TTagBiz() : base()
        {
        }
        public TTagBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
