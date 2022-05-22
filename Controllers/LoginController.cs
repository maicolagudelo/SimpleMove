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
        public IHttpActionResult login(usuarios user, LoginViewController obj)
        {


            
            if (obj != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(user.nombre);
                return Ok(new LoginViewController().Login(user, token));
            }
            else
            {
                string n = "null";
                return Ok(new LoginViewController().Login(user, n));
            }

            
           //var token = TokenGenerator.GenerateTokenJwt(telefono);
           //return Ok(token);
            
        }
    }
}
