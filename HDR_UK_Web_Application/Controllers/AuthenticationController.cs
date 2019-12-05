using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HDR_UK_Web_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HDR_UK_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // POST: api/Authentication
        [HttpPost]
        public IActionResult Authenticate([FromBody] JObject data)
        {
            string username = (string)data["username"];
            string password = (string)data["password"];

            var user = Authentication.AuthenticateUser(username, password);

            if(user.userId == null)
            {
                return BadRequest(new { message = "Incorrect username or password. Please try again."});
            } else
            {
                return Ok(user);
            }

        }
    }
}
