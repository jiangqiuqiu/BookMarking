using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class TLog
    {
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Id {get;set;}

           /// <summary>
           /// Desc:日志类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LogType {get;set;}

           /// <summary>
           /// Desc:登录人/操作者
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LoginName {get;set;}

           /// <summary>
           /// Desc:日志内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Content {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateTime {get;set;}

           /// <summary>
           /// Desc:网址ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string URLID {get;set;}

           /// <summary>
           /// Desc:用户ID——冗余字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserID {get;set;}

    }
}
