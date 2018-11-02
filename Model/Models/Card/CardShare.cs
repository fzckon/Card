using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VCardShare : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 卡Id
        /// </summary>
        public Guid CardId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public CardShareStatus CardShareStatus { get; set; }

    }

    [Table("CardShare")]
    public class CardShare : VCardShare
    {
        public override Guid Id { get; set; }
    }

    public enum CardShareStatus
    {
        [EnumFieldDisplay("删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }
    
}
