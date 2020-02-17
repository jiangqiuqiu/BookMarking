using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookMarking.Data.DataAccess
{
    /// <summary>
    /// 数据库接口
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        IDbConnection Connection { get; }
        /// <summary>
        /// 数据库类型
        /// </summary>

        DatabaseType DatabaseType { get; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        string ConnectionString { get;}
    }
}
