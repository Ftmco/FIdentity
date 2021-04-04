using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPanelApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public async Task<IActionResult> Login()
        {
            return Ok(new
            {
                StatusCode = ,
                ErrorId = 0,
                Title = "Success",
                Result = new { }
            });
        }
    }
}
