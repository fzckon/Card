using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VUserPwd : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [Required]        
        public Guid UserId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required, MaxLength(200)]        
        public string Password { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public PwdStatus PwdStatus { get; set; }


    }

    [Table("UserPwd")]
    public class UserPwd : VUserPwd
    {
        public override Guid Id { get; set; }
    }
    
    public enum PwdStatus 
    {
        [EnumFieldDisplay("历史")]
        His = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }

}
