using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IValidPasswordService _serviceValid;

        public SecurityController(IValidPasswordService validPasswordService)
        {

            _serviceValid = validPasswordService;
        }

        [HttpPost("ValidPassword")]
        public ActionResult ValidPassword(string password)
        {
            var valid =_serviceValid.validPassWord(password);
            
            var messageReturn =valid ? "Valid" : "Invalid";

            return Ok(messageReturn);
        }
    }
}
