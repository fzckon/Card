using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VRole : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
        
    }

    public class Role : VRole
    {
        public override string Id { get; set; }
    }
    
}
