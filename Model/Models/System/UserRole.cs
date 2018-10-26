using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VUserRole : Base
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
        /// 角色Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int UserRoleStatus { get; set; }


    }

    public class UserRole : VUserRole
    {
        public override string Id { get; set; }
    }

    public enum UserRoleStatus
    {
        [EnumFieldDisplay("已删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }
}
