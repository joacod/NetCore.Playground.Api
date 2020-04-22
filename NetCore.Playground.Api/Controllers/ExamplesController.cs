using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Playground.Api.Controllers
{
    [Route("api/v1/examples")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        public ExamplesController()
        {
        }

        /// <summary>
        /// Ping example
        /// </summary>
        /// <returns>pong</returns>
        [HttpGet("ping")]
        public string Get()
        {            
            return "pong";
        }
    }
}