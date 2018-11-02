using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VBank
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [Required, MaxLength(50)]        
        public string BankName { get; set; }

        /// <summary>
        /// 银行简称
        /// </summary>
        [MaxLength(200)]        
        public string BankAbbr { get; set; }

        /// <summary>
        /// 银行名称 英文
        /// </summary>
        [Required, MaxLength(200), Column(TypeName = "varchar(200)")]        
        public string EnBankName { get; set; }

        /// <summary>
        /// 银行简称 英文
        /// </summary>
        [Required, MaxLength(50), Column(TypeName = "varchar(50)")]        
        public string EnBankAbbr { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required, MaxLength(11), Column(TypeName = "varchar(11)")]        
        public string Tel { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        [Required, MaxLength(200)]        
        public string Website { get; set; }

    }
    
    [Table("Bank")]
    public class Bank : VBank
    {
        public override Guid Id { get; set; }
    }
    
}
