/*
 Open Api For Applications
 */

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

        private readonly IAppManager _app;

        public AppController()
        {
            _app = new AppManager();
        }

        #endregion

        #region --Users--

        [HttpGet]
        [Route("GetAppUsers")]
        public async Task<IActionResult> GetUsers(string appToken, int index, int count)
        {
            IList<Users> result = await _app.GetAppUsersAsync(appToken, index, count) as List<Users>;
            return (result != null) ? Ok(new { Id = 0, Title = "Success", Result = result }) :
                Ok(new { Id = -1, Title = "Not Found Any Users", Result = new { } });
        }

        #endregion

        #region --App Info--

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

        #endregion

        #region --Delete User--

        [HttpGet]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string appKey,string userId)
        {
            return Ok();
        }

        #endregion
    }
}
