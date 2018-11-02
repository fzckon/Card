using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VBill : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 卡片Id
        /// </summary>
        [Required]
        public Guid CardId { get; set; }

        /// <summary>
        /// 账单日
        /// </summary>
        [Required]
        public DateTime BillingDate { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        [Required]
        public DateTime RepayDate { get; set; }

        /// <summary>
        /// 账单金额
        /// </summary>
        [Required]
        public decimal BillAmount { get; set; }

        /// <summary>
        /// 还款金额
        /// </summary>
        [Required]
        public decimal RepayAmount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        public BillStatus BillStatus { get; set; }


    }

    [Table("Bill")]
    public class Bill : VBill
    {
        public override Guid Id { get; set; }
    }

    public class BillQuery : VBill
    {
        public Guid UserId { get; set; }
    }

    public enum BillStatus
    {
        [EnumFieldDisplay("已删除")]
        Del = 0,

        [EnumFieldDisplay("生成账单")]
        Billing = 1,

        [EnumFieldDisplay("全额还款")]
        Billed = 2,

        [EnumFieldDisplay("部分还款")]
        Tobill = 4,

        [EnumFieldDisplay("分期还款")]
        Instalment = 8,
    }
}
