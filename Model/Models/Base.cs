using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models
{
    public class Base
    {
        public Base(int create = 0)
        {
            if (create > 0)
                CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

    }

    public class Create : Base
    {
        public virtual Guid CreateUser { get; set; }
    }

}
