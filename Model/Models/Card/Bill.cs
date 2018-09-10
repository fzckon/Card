using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VBill : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 卡片Id
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 账单日
        /// </summary>
        public DateTime BillingDate { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public DateTime RepayDate { get; set; }

        /// <summary>
        /// 账单金额
        /// </summary>
        public decimal BillAmount { get; set; }

        /// <summary>
        /// 还款金额
        /// </summary>
        public decimal RepayAmount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int BillStatus { get; set; }


    }

    public class Bill : VBill
    {
        public override string Id { get; set; }
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
