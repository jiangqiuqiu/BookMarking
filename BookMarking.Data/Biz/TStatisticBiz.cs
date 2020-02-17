using BookMarking.Data.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Biz
{
    public class TStatisticBiz: TStatisticRepository
    {
        public static readonly TStatisticBiz Instance = new TStatisticBiz();
        private TStatisticBiz() : base()
        {
        }
        public TStatisticBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
