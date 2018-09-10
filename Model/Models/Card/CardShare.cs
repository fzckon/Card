using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VCardShare : Base
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
        /// 卡Id
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int CardShareStatus { get; set; }


    }

    public class CardShare : VCardShare
    {
        public override string Id { get; set; }
    }

    public enum CardShareStatus
    {
        [EnumFieldDisplay("删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

    }
    
}
