using BookMarking.Data.Base;
using BookMarking.Data.Dal.Domain;
using BookMarking.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.Dal.Repository
{
    public class TFolderRepository: Respository, ITFolderRepository
    {
        protected TFolderRepository() : base()
        {
        }
        protected TFolderRepository(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }

        //如果要连不同数据库，可以采用这种方式
        //public TFolderRepository()
        //{
        //    SetDBSession(DBHelper.CreateDBSession(conn: "setting:MyOtherMysql", databaseType: DatabaseType.MySql));
        //}
    }
}
