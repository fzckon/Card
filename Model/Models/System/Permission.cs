using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
    public class VPermission : Base
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        [Required]
        public PermissionType PermissionType { get; set; }

        /// <summary>
        /// 权限名
        /// </summary>
        [Required, MaxLength(50)]        
        public string PermissionName { get; set; }

        /// <summary>
        /// 权限代码
        /// Menu_
        /// File_
        /// Elements_
        /// Other_
        /// Operate_Add
        /// Operate_Edit
        /// </summary>
        [Required, MaxLength(200), Column(TypeName = "varchar(200)")]
        public string PermissionCode { get; set; }

    }

    [Table("Permission")]
    public class Permission : VPermission
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }
    }

    public enum PermissionType
    {
        [EnumFieldDisplay("")]
        Empty = 0,

        [EnumFieldDisplay("菜单")]
        Menu = 1,

        [EnumFieldDisplay("操作")]
        Operate = 2,

        [EnumFieldDisplay("文件")]
        File = 3,

        [EnumFieldDisplay("元素")]
        Elements = 4,
        
        [EnumFieldDisplay("其他")]
        Other = 9,
    }
}
