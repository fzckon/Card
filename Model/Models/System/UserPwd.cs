using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VUserPwd : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public int PwdStatus { get; set; }


    }

    public class UserPwd : VUser
    {
        public override string Id { get; set; }
    }
    
    public enum PwdStatus 
    {
        [EnumFieldDisplay("历史")]
        His = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }

}
