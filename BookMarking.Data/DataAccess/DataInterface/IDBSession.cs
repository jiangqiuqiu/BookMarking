using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookMarking.Data.DataAccess
{
    /// <summary>
    /// 数据连接事务的Session接口
    /// </summary>
    public interface IDBSession : IDisposable
    {
        DatabaseType DatabaseType { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
}
