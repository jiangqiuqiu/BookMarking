using BookMarking.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookMarking.Data.Base
{
    public interface IDataRepository
    {
        IDBSession DBSession { get; }
        int Execute(string sql, dynamic param = null,IDbTransaction transaction = null);
        IEnumerable<T> Get<T>(string sql, dynamic param = null, bool buffered = true) where T : class;
    }
}
