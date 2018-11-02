using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VMenu : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public virtual Guid PId { get; set; }
        
        /// <summary>
        /// 菜单名
        /// </summary>
        [Required, MaxLength(50)]        
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单代码
        /// Menu_Card_CardList
        /// Menu_Card_BillList
        /// </summary>
        [Required, MaxLength(200), Column(TypeName = "varchar(200)")]
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单Url
        /// </summary>
        [Required, MaxLength(200)]
        public string MenuUrl { get; set; }
    }

    [Table("Menu")]
    public class Menu : VMenu
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
    }
    
}
