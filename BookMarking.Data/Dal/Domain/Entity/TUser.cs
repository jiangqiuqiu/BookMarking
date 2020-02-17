using System;
using System.Linq;
using System.Text;

namespace BookMarking.Data.Dal.Domain
{
    ///<summary>
    ///
    ///</summary>
    public partial class TUser
    {
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserId {get;set;}

        /// <summary>
        /// Desc:用户名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UserName {get;set;}

        /// <summary>
        /// Desc:性别
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Gender {get;set;}

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Pwd {get;set;}

        /// <summary>
        /// Desc:所处行业
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Industry {get;set;}

        /// <summary>
        /// Desc:电话号码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PhoneNumber {get;set;}

        /// <summary>
        /// Desc:电子邮箱
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Email {get;set;}

        /// <summary>
        /// Desc:QQ号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string QQ {get;set;}

        /// <summary>
        /// Desc:微信号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WeChat {get;set;}

        /// <summary>
        /// Desc:是否锁定 0:启用 1:锁定
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? IsLock { get; set; } = 0;

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateTime {get;set;}

    }
}
