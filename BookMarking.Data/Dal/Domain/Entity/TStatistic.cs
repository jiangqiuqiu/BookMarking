using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class TStatistic
    {
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Id {get;set;}

           /// <summary>
           /// Desc:网址ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string URLID {get;set;}

           /// <summary>
           /// Desc:浏览次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BrowseNum {get;set;}

           /// <summary>
           /// Desc:最后一次访问时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastVisitTime {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateTime {get;set;}

    }
}
