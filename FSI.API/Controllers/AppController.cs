using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Repository;
using Services.Services.Srevices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        #region __Dependency__

        private readonly IAppRepository _app;

        public AppController()
        {
            _app = new AppServices();
        }

        #endregion

        [HttpGet]
        [Route("GetAppUsers")]
        public async Task<IActionResult> GetUsers(string appKey, int index, int count)
        {
            IList<Users> result = await _app.GetAppUsersAsync(appKey, index, count) as List<Users>;
            return (result != null) ? Ok(new { Id = 0, Title = "Success", Result = result }) :
                Ok(new { Id = -1, Title = "Not Found Any Users", Result = new { } });
        }

        [HttpGet]
        [Route("GetAppInfo")]
        public async Task<IActionResult> GetMyAppInfo(string appKey)
        {
            var result = await _app.GetApplicationInfoAsync(appKey, HttpContext.Request.Headers);

            switch (result.Status)
            {
                case ApplicationInfoStatus.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = result });
                case ApplicationInfoStatus.AppNotfound:
                    return Ok(new { Id = -1, Title = "App Not found", Result = new { } });
                case ApplicationInfoStatus.Exception:
                    return Ok(new { Id = -2, Title = "Exception", Result = new { } });
                default:
                    goto case ApplicationInfoStatus.Exception;
            }
        }
    }
}
