using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VBank
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行简称
        /// </summary>
        public string BankAbbr { get; set; }

        /// <summary>
        /// 银行名称 英文
        /// </summary>
        public string EnBankName { get; set; }

        /// <summary>
        /// 银行简称 英文
        /// </summary>
        public string EnBankAbbr { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string Website { get; set; }

    }

    public class Bank : VBank
    {
        public override string Id { get; set; }
    }
    
}
