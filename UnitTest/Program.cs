using BookMarking.Common.Log;
using BookMarking.Data.Biz;
using BookMarking.Data.Dal.Domain;
using DapperExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TUser user = new TUser();
            user.UserId = Guid.NewGuid().ToString();
            user.UserName = "测试";
            user.PhoneNumber = "111";
            user.Pwd = "111";

            //插入
            //TUserBiz.Instance.Insert(user);

            //获取数量
            var pgCount = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pgCount.Predicates.Add(Predicates.Field<TUser>(f => f.UserId, Operator.Eq, null, not: true));
            var count = TUserBiz.Instance.Count<TUser>(pgCount);

        }
    }
}
