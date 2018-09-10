using System;
using System.Collections.Generic;
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
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }

    public class Create : Base
    {
        public Guid CreateUser { get; set; }
    }

}
