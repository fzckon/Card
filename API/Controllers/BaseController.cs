using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Card;
using EF.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Card.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CardContext _cardContext;
        protected readonly LogContext _logContext;

        public BaseController(CardContext cardContext, LogContext logContext)
        {
            _cardContext = cardContext;
            _logContext = logContext;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Error()
        {
            var re = Request;
            return Content("");
        }
    }
}