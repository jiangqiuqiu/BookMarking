using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace BookMarking.Data.DataAccess
{
    /// <summary>
    /// 数据库类对象
    /// </summary>
    public class Database : IDatabase
    {
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IDbConnection Connection { get; private set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType { get;private set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get;private set; }

        public Database(IDbConnection connection)
        {
            Connection = connection;
        }

        public Database(string conn = "", 
                        string jsonConfigFileName = "appsettings.json", 
                        DatabaseType databaseType = DatabaseType.MySql)
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile(jsonConfigFileName, optional: true)
                             .Build();
            if (string.IsNullOrEmpty(conn))
            {
                conn = config.GetSection("Connections:DefaultConnect").Value;
            }
            else if (conn.StartsWith("setting:"))
            {
                conn = config.GetSection(conn.Substring(8)).Value;
            }
            ConnectionString = conn;
            Connection = ConnectionFactory.CreateConnection(ConnectionString, databaseType);
        }
    }
}
