using BookMarking.Data.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Biz
{
    public class TFolderBiz: TFolderRepository
    {
        public static readonly TFolderBiz Instance = new TFolderBiz();
        private TFolderBiz() : base()
        {
        }
        public TFolderBiz(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
