using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VUser : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [Required, MaxLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 大写拼音全称 
        /// 张三全 ZHANG SAN QUAN
        /// </summary>
        [Required, MaxLength(200)]
        public string FullName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Required, MaxLength(11)]
        public string Tel { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public UserStatus Status { get; set; }

        public void SetFullName()
        {

        }
    }

    [Table("User")]
    public class User : VUser
    {
        public override Guid Id { get; set; }
    }

    public class LoginUser
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }

    public enum Sex
    {
        [EnumFieldDisplay("其他")]
        Other = 0,

        [EnumFieldDisplay("男")]
        Male = 1,

        [EnumFieldDisplay("女")]
        Female = 2,
    }

    public enum Status
    {
        [EnumFieldDisplay("已删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }

    public enum UserStatus
    {
        [EnumFieldDisplay("已删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }

}
