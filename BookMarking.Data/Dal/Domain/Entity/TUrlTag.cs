using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class turltag
    {
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Id {get;set;}

           /// <summary>
           /// Desc:标签ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TagID {get;set;}

           /// <summary>
           /// Desc:网址ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string URLID {get;set;}

    }
}
