using BookMarking.Data.DataAccess;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookMarking.Data.Base
{
    public class Respository:IServiceRepository,IDataRepository,IDisposable
    {
        public IDBSession DBSession { get; private set; }
        public Respository()
        {
            DBSession= DBHelper.CreateDBSession();
        } 
        
        protected Respository(string conn = "", DatabaseType databaseType = DatabaseType.MySql)
        {
            DBSession = DBHelper.CreateDBSession(conn,databaseType);
        }

        #region 查询


        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public T GetById<T>(dynamic primaryId) where T : class
        {
            return DBSession.Connection.Get<T>(primaryId as object);
        }

        /// <summary>
        ///根据多个Id获取多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primarykey">主键名</param>
        /// <param name="ids"></param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public IEnumerable<T> GetByIds<T>(string primarykey, IList<dynamic> ids, string tablename = "") where T : class
        {

            if (string.IsNullOrEmpty(tablename))
                tablename = typeof(T).Name;
            tablename = string.Format("dbo.{0}", tablename);
            string idsin = string.Join(",", ids.ToArray<dynamic>());
            string sql = $"SELECT * FROM {tablename} WHERE {primarykey} in ({idsin})";
            IEnumerable<T> dataList = DBSession.Connection.Query<T>(sql);
            return dataList;
        }

        /// <summary>
        /// 获取全部数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return DBSession.Connection.GetList<T>();
        }

        /// <summary>
        ///统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public int Count<T>(object predicate, bool buffered = false) where T : class
        {
            return DBSession.Connection.Count<T>(predicate);
        }

        /// <summary>
        /// 查询列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">条件</param>
        /// <param name="sort">排序</param>
        /// <param name="buffered">缓存</param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(object predicate = null, IList<ISort> sort = null,
            bool buffered = false) where T : class
        {
            return DBSession.Connection.GetList<T>(predicate, sort, null, null, buffered);
        }

        /// <summary>
        ///     分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="allRowsCount">总数</param>
        /// <param name="predicate">条件</param>
        /// <param name="sort">排序</param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPageList<T>(int pageIndex, int pageSize, out long allRowsCount,
            object predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class
        {
            if (sort == null)
                sort = new List<ISort>();

            IEnumerable<T> entityList = DBSession.Connection.GetPage<T>(predicate, sort, pageIndex, pageSize, null, null,buffered);
            allRowsCount = DBSession.Connection.Count<T>(predicate);
            return entityList;
        }

        #endregion

        #region 插入

        /// <summary>
        /// 插入单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public dynamic Insert<T>(T entity, IDbTransaction transaction = null) where T : class
        {
            dynamic result = DBSession.Connection.Insert(entity, transaction);
            return result;
        }

        /// <summary>
        ///批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        public bool InsertBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class
        {
            bool isOk = false;
            foreach (T item in entityList)
            {
                Insert(item, transaction);
            }
            isOk = true;
            return isOk;

        }

        #endregion

        #region 更新

        /// <summary>
        ///更新单条记录,注意：entity全部字段都要赋值，否则会变null或0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update<T>(T entity, IDbTransaction transaction = null) where T : class
        {
            bool isOk = DBSession.Connection.Update(entity, transaction);
            return isOk;
        }

        /// <summary>
        ///批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class
        {
            bool isOk;
            foreach (T item in entityList)
            {
                Update(item, transaction);
            }
            isOk = true;
            return isOk;
        }
        #endregion

        #region 删除

        /// <summary>
        ///删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class
        {
            var entity = GetById<T>(primaryId);
            var obj = entity as T;
            bool isOk = DBSession.Connection.Delete(obj);
            return isOk;
        }

        /// <summary>
        ///条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DeleteList<T>(object predicate = null, IDbTransaction transaction = null) where T : class
        {
            return DBSession.Connection.Delete<T>(predicate, transaction);
        }

        /// <summary>
        ///批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DeleteBatch<T>(IEnumerable<dynamic> ids, IDbTransaction transaction = null) where T : class
        {
            bool isOk;
            foreach (dynamic id in ids)
            {
                Delete<T>(id, transaction);
            }
            isOk = true;
            return isOk;
        }
        #endregion

        #region 数据接口实现
        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null)
        {
            return DBSession.Connection.Execute(sql, param as object, transaction);
        }
        public IEnumerable<T> Get<T>(string sql, dynamic param = null, bool buffered = true) where T : class
        {
            return DBSession.Connection.Query<T>(sql, param as object, DBSession.Transaction, buffered);
        }
        #endregion
        public void Dispose()
        {
            DBSession.Dispose();
        }

        
    }
}
