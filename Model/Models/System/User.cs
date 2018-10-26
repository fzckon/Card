using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VUser : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 大写拼音全称 
        /// 张三全 ZHANG SAN QUAN
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        public void SetFullName()
        {

        }
    }

    public class User : VUser
    {
        public override string Id { get; set; }
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
