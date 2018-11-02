using Common.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceController.Card
{
    public class AuthorizeAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (!filterContext.HttpContext.Session.IsAvailable) return;

            byte[] value;
            if (!filterContext.HttpContext.Session.TryGetValue("CurrentUser", out value)) return;
            var user = ByteConvertHelper.Bytes2Object<User>(value);
            if (user == null) return;
        }
    }
}
