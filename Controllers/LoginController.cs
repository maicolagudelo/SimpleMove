using SimpleMove.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SimpleMove.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        
        [HttpPost]
        [Route("login")]
        public IHttpActionResult login(LoginViewController telefono)
        {

            return Ok();
           //var token = TokenGenerator.GenerateTokenJwt(telefono);
           //return Ok(token);
            
        }
    }
}
