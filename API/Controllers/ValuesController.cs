using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Card;
using EF.Log;
using EF.Card.Respository;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Microsoft.Extensions.Logging;
//using NLog;

namespace API.Card.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        protected ILogger<ValuesController> logger;
        static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public ValuesController(CardContext cardContext, LogContext logContext, ILogger<ValuesController> logger) : base(cardContext, logContext)
        {

            //var logs = logContext.Logs;
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //throw new Exception("???");
            try
            {
                throw new Exception("???");
            }
            catch (Exception ex)
            {
                
                logger.LogError(ex, "LogError");
                logger.LogInformation("-----------Information-----------");
                Logger.Error(ex, "Error");
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
