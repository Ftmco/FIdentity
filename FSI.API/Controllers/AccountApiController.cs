/*
 Open Api For Account Users
 */

using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FSI.Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        #region --Dependency--

        /// <summary>
        /// Account Manager
        /// </summary>
        private readonly IAccountManager _account;

        public AccountApiController()
        {
            _account = new AccountManager();
        }

        #endregion

        #region --Login--

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            LoginResponse result = await _account.LoginAsync(login, 20, HttpContext);

            switch (result.Status)
            {
                case LoginStatus.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = result });
                case LoginStatus.Exception:
                    return BadRequest(new { Id = -2, Title = "Exception", Result = new { } });
                case LoginStatus.WrongPassword:
                    return BadRequest(new { Id = -3, Title = "Wrong Password", Result = new { } });
                case LoginStatus.UserNotFound:
                    return NotFound(new { Id = -4, Title = "User Not Found", Result = new { } });

                default:
                    goto case LoginStatus.Exception;
            }
        }

        #endregion

        #region --SignUp--

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignupViewModel signUp)
        {
            SignUpResponse result = await _account.SignUpAsync(signUp, HttpContext.Request.Headers);

            switch (result)
            {
                case SignUpResponse.Success:
                    return Ok(new { Id = 0, Title = "Success Go To Active Account", Result = new { } });
                case SignUpResponse.Exception:
                    return BadRequest(new { Id = -2, Title = "Exception", Result = new { } });
                case SignUpResponse.UserAlreadyExist:
                    return BadRequest(new { Id = -3, Title = "User Already Exist", Result = new { } });
                case SignUpResponse.AppNotFound:
                    return NotFound(new { Id = -4, Title = "User Signed In But Wrong Application Token try To Login With Application Token", Result = new { } });
                case SignUpResponse.AppActivent:
                    return BadRequest(new { Id = -5, Title = "User Signed In But Application is`t Active try To Login With Application Token", Result = new { } });
                case SignUpResponse.AppIsntForYou:
                    return BadRequest(new { Id = -6, Title = "User Signed In But You Are Is`t Owner Of This Applications try To Login With Application Token", Result = new { } });
                default:
                    goto case SignUpResponse.Exception;
            }

        }

        #endregion

        #region --Activation--

        [HttpPost]
        [Route("Activation")]
        public async Task<IActionResult> Activation(ActivationViewModel activation)
        {
            ActivationResponse result = await _account.ActiveUserAsync(activation);

            switch (result.Status)
            {
                case ActivationResponseEn.Success:
                    return Ok(new { Id = 0, Title = "User Actived", Result = result.Success });
                case ActivationResponseEn.UserNotFound:
                    return NotFound(new { Id = -1, Title = "UserNotFound", Result = new { } });
                case ActivationResponseEn.WrongActiveCode:
                    return BadRequest(new { Id = -3, Title = "Wrong ActiveCode", Result = new { } });
                case ActivationResponseEn.Exception:
                    return BadRequest(new { Id = -3, Title = "Exception", Result = new { } });

                default:
                    goto case ActivationResponseEn.Exception;
            }
        }

        #endregion

        #region --Recovery Password--

        [HttpPost]
        [Route("RecoveryPassword")]
        public async Task<IActionResult> RecoveyPassword(RecoveryPasswordViewModel recoveryPassword)
        {
            var result = await _account.RequestRecoveyPassword(recoveryPassword);

            switch (result)
            {
                case RecoveryPasswordResponse.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = new { } });
                case RecoveryPasswordResponse.UserNotFound:
                    return NotFound(new { Id = -1, Title = "User Not Found", Result = new { } });
                case RecoveryPasswordResponse.Exception:
                    return BadRequest(new { Id = -2, Title = "Exception", Result = new { } });
                case RecoveryPasswordResponse.WrongRecoveryCode:
                    return BadRequest(new { Id = -3, Title = "Wrong Recovey Code", Result = new { } });
                default:
                    goto case RecoveryPasswordResponse.Exception;
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            var result = await _account.RequestChangePasswordAsync(changePassword, HttpContext.Request.Headers);
            switch (result)
            {
                case ChangePasswordResponse.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = new { } });
                case ChangePasswordResponse.UserNotFound:
                    return NotFound(new { Id = -1, Title = "User Not Found", Result = new { } });
                case ChangePasswordResponse.Exception:
                    return BadRequest(new { Id = -2, Title = "Exception", Result = new { } });
                case ChangePasswordResponse.WrongOldPassword:
                    return BadRequest(new { Id = -3, Title = "Wrong Password", Result = new { } });
                default:
                    goto case ChangePasswordResponse.Exception;
            }
        }

        #endregion
    }
}
