using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class TTag
    {
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string TagId {get;set;}

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UserID {get;set;}

        /// <summary>
        /// Desc:标签名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string TagName {get;set;}

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateTime {get;set;}

        /// <summary>
        /// Desc:1:已删除 0:没删除
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? IsDelete { get; set; } = 0;

    }
}
