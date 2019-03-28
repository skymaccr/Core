using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IConfiguration config;

        public OperationsController(IConfiguration config)
        {
            this.config = config;
        }


        //OPtions se utiliza para crear functional API's como restaurar un servidor, levantar un servicio, 
        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot)config;
                root.Reload();
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}