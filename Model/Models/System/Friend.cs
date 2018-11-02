using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VFriend : Base
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
        /// 朋友Id
        /// </summary>
        [Required]        
        public Guid FriendId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]        
        public FriendStatus FriendStatus { get; set; }


    }

    [Table("Friend")]
    public class Friend : VFriend
    {
        public override Guid Id { get; set; }
    }

    

    public enum FriendStatus
    {
        [EnumFieldDisplay("已删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

        [EnumFieldDisplay("黑名单")]
        Billed = 2,

        [EnumFieldDisplay("白名单")]
        Tobill = 4,

        [EnumFieldDisplay("星标")]
        Instalment = 8,
    }
}
