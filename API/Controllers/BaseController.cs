using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Card;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Card.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CardContext _cardContext;

        public BaseController(CardContext cardContext)
        {
            _cardContext = cardContext;
        }

    }
}