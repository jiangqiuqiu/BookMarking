using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Data.DataAccess
{
    public class DBHelper
    {
        /// <summary>
        /// 根据配置文件获取字符串创建连接对象和DBSession
        /// </summary>
        /// <param name="conn">默认为空，从Connections:DefaultConnect配置节中读取</param>
        /// <param name="databaseType">默认为MySql</param>
        /// <returns></returns>
        public static DBSession CreateDBSession(string conn = "", DatabaseType databaseType = DatabaseType.MySql)
        {
            return new DBSession(new Database(conn,databaseType: databaseType));
        }
    }
}
