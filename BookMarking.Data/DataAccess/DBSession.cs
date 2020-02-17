using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookMarking.Data.DataAccess
{
    /// <summary>
    /// 数据库连接事务的Session对象
    /// </summary>
    public class DBSession:IDBSession
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType { get; }
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IDbConnection Connection { get; private set; }

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        public IDbTransaction Transaction { get; private set; }

        public DBSession(IDatabase database)
        {
            Connection = database.Connection;
            DatabaseType = database.DatabaseType;
        }

        /// <summary>
        /// 开启会话
        /// </summary>
        /// <param name="isolation"></param>
        /// <returns></returns>
        public IDbTransaction Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {
            Connection.Open();
            Transaction = Connection.BeginTransaction(isolation);
            return Transaction;
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void Commit()
        {
            Transaction.Commit();
            Transaction = null;
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void Rollback()
        {
            Transaction.Rollback();
            Transaction = null;
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                    Transaction = null;
                }
                Connection.Close();
                Connection = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
