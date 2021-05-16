using FTeam.Entity.Applications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NPanelReactApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {

        [Route("GetApplications")]
        [HttpGet]
        public IActionResult GetApplications()
        {
            IList<Applications> result = new List<Applications>();
            result.Add(new()
            {
                Id = Guid.NewGuid(),
                ApplicationEmail = "a@gmail.com",
                ApplicationIcon = "test.jpg",
                ApplicationName = "test Applications",
                ApplicationPassword = "as;d;kas kkdpasi ",
                CreateDate = DateTime.Now,
                IsConfirm = true
            });

            result.Add(new()
            {
                ApplicationEmail = "a@gmail.com2",
                ApplicationIcon = "test2.jpg",
                Id = Guid.NewGuid(),
                ApplicationName = "test Applications2",
                ApplicationPassword = "as;d;kas kkdpasi 2",
                CreateDate = DateTime.Now,
                IsConfirm = false
            });

            return Ok(result);
        }
    }
}
