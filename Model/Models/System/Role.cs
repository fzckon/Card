using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VRole : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [Required, MaxLength(50)]        
        public string RoleName { get; set; }

    }

    [Table("Role")]
    public class Role : VRole
    {
        public override Guid Id { get; set; }
    }
    
}
