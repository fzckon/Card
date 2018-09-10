using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VCard : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 银行Id
        /// </summary>
        public string BankId { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string OpenBankName { get; set; }

        /// <summary>
        /// 卡片类型 1 信用卡 2 储蓄卡 3 存折
        /// </summary>
        public int CardType { get; set; }

        /// <summary>
        /// 卡片组织 
        /// 1 银联 UnionPay  
        /// 2 威士 VISA 
        /// 4 万事达 MasterCard 
        /// 8 运通 Express 
        /// 16 日本国际信用卡 JCB 
        /// 32 大来卡 Diners 
        /// </summary>
        public int CardOrg { get; set; }

        /// <summary>
        /// 卡片等级
        /// 1 普卡 Common
        /// 2 金卡 Gold
        /// 3 白金卡 Platinum 
        /// 4 钻石卡 Diamond
        /// 5 黑卡 Centurion
        /// 6 钛金卡 Titanium
        /// 7 世界卡 WorldElite
        /// 8 御玺卡 Signature
        /// 9 无限卡 Visainfinite
        /// 10 绿卡 Green
        /// </summary>
        public int CardLevel { get; set; }

        /// <summary>
        /// 币种
        /// 1 单币种
        /// 2 双币种
        /// 3 全币种/多币种
        /// </summary>
        public int? CardCurrency { get; set; }

        /// <summary>
        /// 卡片号码
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 卡片Cvv
        /// </summary>
        public string CardCvv { get; set; }

        /// <summary>
        /// 卡片Cvv2
        /// </summary>
        public string CardCvv2 { get; set; }

        /// <summary>
        /// 卡片名称
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// 卡片额度
        /// </summary>
        public decimal? CardAmount { get; set; }

        /// <summary>
        /// 卡片临时额度
        /// </summary>
        public decimal? CardTempAmount { get; set; }

        /// <summary>
        /// 有效期 
        /// 到期时间 2020-12-12
        /// 1220
        /// </summary>
        public string ValidThru { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ValidDate { get; set; }

        /// <summary>
        /// 预留电话
        /// </summary>
        public string ReservedTel { get; set; }

        /// <summary>
        /// 查询密码
        /// </summary>
        public string QPassword { get; set; }

        /// <summary>
        /// 取款密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 账单日
        /// 每月几号
        /// </summary>
        public int? BillingDay { get; set; }

        /// <summary>
        /// 还款日
        /// 每月几号
        /// </summary>
        public int? RepayDay { get; set; }

        /// <summary>
        /// 办卡时间
        /// </summary>
        public DateTime HandleDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int CardStatus { get; set; }

        public void SetCvv()
        {
            if (!string.IsNullOrEmpty(CardCvv))
                CardCvv2 = CardCvv.Substring(4);
        }
    }

    public class CardInfo : VCard
    {
        public override string Id { get; set; }
    }
    
    public class CardModel : VCard
    {

    }

    public enum CardStatus
    {
        [EnumFieldDisplay("已删除")]
        Del = 0,

        [EnumFieldDisplay("正常")]
        Normal = 1,

        [EnumFieldDisplay("销卡")]
        Cancel = 2,

    }

    public enum CardType
    {
        [EnumFieldDisplay("信用卡")]
        Credit = 1,

        [EnumFieldDisplay("储蓄卡")]
        Deposit = 2,

        [EnumFieldDisplay("存折")]
        bankbook = 3,

    }


    public enum CardOrg
    {
        [EnumFieldDisplay("银联")]
        UnionPay = 1,

        [EnumFieldDisplay("威士")]
        VISA = 2,

        [EnumFieldDisplay("万事达")]
        MasterCard = 4,

        [EnumFieldDisplay("运通")]
        Express = 8,

        [EnumFieldDisplay("日本国际信用卡")]
        JCB = 16,

        [EnumFieldDisplay("大来卡")]
        Diners = 32,

    }

    public enum CardLevel
    {
        [EnumFieldDisplay("普卡")]
        Common = 1,

        [EnumFieldDisplay("金卡")]
        Gold = 2,

        [EnumFieldDisplay("白金卡")]
        Platinum = 3,

        [EnumFieldDisplay("钻石卡")]
        Diamond = 4,

        [EnumFieldDisplay("黑卡")]
        Centurion = 5,

        [EnumFieldDisplay("钛金卡")]
        Titanium = 6,

        [EnumFieldDisplay("世界卡")]
        WorldElite = 7,

        [EnumFieldDisplay("御玺卡")]
        Signature = 8,

        [EnumFieldDisplay("无限卡")]
        Visainfinite = 9,

        [EnumFieldDisplay("绿卡")]
        Green = 10,
    }

    public enum CardCurrency
    {
        [EnumFieldDisplay("单币种")]
        Single = 1,

        [EnumFieldDisplay("双币种")]
        Double = 2,

        [EnumFieldDisplay("全币种/多币种")]
        All = 3,

    }

}
