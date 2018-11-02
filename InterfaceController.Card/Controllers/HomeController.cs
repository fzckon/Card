using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF.Card;
using EF.Log;
using Model.Models;
using EF.System.Respository;
using EF.System;
using Newtonsoft.Json;
using Common.Utils;

namespace InterfaceController.Card.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        protected readonly SystemContext _systemContext;
        private UserRepository userRepo;
        protected override void Dispose(bool disposing)
        {
            if (userRepo != null) userRepo.Dispose();
            base.Dispose(disposing);
        }

        public HomeController(SystemContext systemContext)
        {
            userRepo = new UserRepository(_systemContext);
        }

        // POST: api/Bank
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new InterfaceRep
                {
                    succeed = InterfaceRepSucceed.Fail,
                    msg = "校验失败",
                    data = ModelState,
                });
            }

            User user = await userRepo.LoginAsync(loginUser);
            if (user == null)
                return BadRequest(new InterfaceRep
                {
                    succeed = InterfaceRepSucceed.Fail,
                    msg = "用户名错误",
                });

            if (user.Id == Guid.Empty)
                return BadRequest(new InterfaceRep
                {
                    succeed = InterfaceRepSucceed.Fail,
                    msg = "密码错误",
                });

            HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));

            return Ok(new InterfaceRep
            {
                succeed = InterfaceRepSucceed.Success,
                msg = "登录成功",
            });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HttpContext.Session.Remove("CurrentUser");

            return Ok(new InterfaceRep
            {
                succeed = InterfaceRepSucceed.Success,
                msg = "退出登录成功",
            });
        }

    }
}