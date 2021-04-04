using FTeam.ViewModels.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NPanelApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public async Task<IActionResult> Login()
        {
            return Ok(new ApiResponse
            {
                ErrorId = 0,
                Result = new { },
                Status = Status.Status200OK,
                Title = "Success"
            });
        }

        public async Task<IActionResult> Singup()
        {
            return Ok(new ApiResponse
            {
                ErrorId = 0,
                Result = new { },
                Status = Status.Status200OK,
                Title = "Success"
            });
        }

        public async Task<IActionResult> ChangePassword()
        {
            return Ok(new ApiResponse
            {
                ErrorId = 0,
                Result = new { },
                Status = Status.Status200OK,
                Title = "Success"
            });
        }

        public async Task<IActionResult> ForgetPassword()
        {
            return Ok(new ApiResponse
            {
                ErrorId = 0,
                Result = new { },
                Status = Status.Status200OK,
                Title = "Success"
            });
        }

        public async Task<IActionResult> RecoveryPassword()
        {
            return Ok(new ApiResponse
            {
                ErrorId = 0,
                Result = new { },
                Status = Status.Status200OK,
                Title = "Success"
            });
        }

        public async Task<IActionResult> Activation()
        {
            return Ok(new ApiResponse
            {
                ErrorId = 0,
                Result = new { },
                Status = Status.Status200OK,
                Title = "Success"
            });
        }
    }
}
