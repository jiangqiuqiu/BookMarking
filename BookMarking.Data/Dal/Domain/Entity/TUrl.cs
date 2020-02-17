using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class TUrl
    {
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string URLId {get;set;}

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UserID {get;set;}

        /// <summary>
        /// Desc:网页名称WebName
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WName {get;set;}

        /// <summary>
        /// Desc:网址
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string URL {get;set;}

        /// <summary>
        /// Desc:文件夹ID，表明该网址属于哪个文件夹
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string FolderID {get;set;}

        /// <summary>
        /// Desc:1:没失效 0:失效
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public int? IsEfficacy { get; set; } = 1;

        /// <summary>
        /// Desc:1:删除   0:没删除
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? IsDelete { get; set; } = 0;

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateTime {get;set;}

    }
}
