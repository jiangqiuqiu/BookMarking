using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class TFolder
    {
           
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string FolderId {get;set;}

        /// <summary>
        /// Desc:文件夹名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string FolderName {get;set;}

        /// <summary>
        /// Desc:级别
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Level {get;set;}

        /// <summary>
        /// Desc:父级ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ParentID {get;set;}

        /// <summary>
        /// Desc:当前路径
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CurRoute {get;set;}

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UserID {get;set;}

        /// <summary>
        /// Desc:1:删除 0:没删除
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
