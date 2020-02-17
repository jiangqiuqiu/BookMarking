using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace BookMarking.Data.DataAccess
{
    /// <summary>
    /// 数据库链接工厂类
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection(string strConn, DatabaseType databaseType = DatabaseType.MySql)
        {
            IDbConnection connection = null;
            //获取配置进行转换
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    break;
                case DatabaseType.MySql:
                    DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();//必须设置MySql方言，因为DapperExtension默认是SQLServer的
                    connection = new MySqlConnection(strConn);
                    break;
                case DatabaseType.Sqlite:                   
                    break;
                case DatabaseType.Oracle:                    
                    break;
            }
            return connection;
        }
    }
}
