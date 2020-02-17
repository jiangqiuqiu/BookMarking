using BookMarking.Data.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Biz
{
    public class TUrlTagBiz: TUrlTagRepository
    {
        public static readonly TUrlTagBiz Instance = new TUrlTagBiz();
        private TUrlTagBiz() : base()
        {
        }
        public TUrlTagBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
