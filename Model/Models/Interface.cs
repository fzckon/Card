using Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class InterfaceRep
    {
        public InterfaceRepSucceed succeed { get; set; }

        public string code { get; set; }

        public string msg { get; set; }

        public object data { get; set; }
    }

    public class InterfaceReq
    {

    }


    public enum InterfaceRepSucceed
    {
        [EnumFieldDisplay("失败")]
        Fail = 0,

        [EnumFieldDisplay("成功")]
        Success = 1,

    }
}
