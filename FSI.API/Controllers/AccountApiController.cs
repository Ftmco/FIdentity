﻿using Fri2Ends.Identity.Services.Repository;
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
            LoginResponse result = await _account.LoginAsync(login, login.RememberMe, 20, HttpContext);

            switch (result.Status)
            {
                case LoginStatus.Success:
                    return Ok((Id: 0, Title: "Success", Result: result.Status));
                case LoginStatus.Exception:
                    return Ok((Id: -2, Title: "Exception", Result: new { }));
                case LoginStatus.WrongPassword:
                    return Ok((Id: -3, Title: "Wrong Password", Result: new { }));
                case LoginStatus.UserNotFound:
                    return Ok((Id: -4, Title: "User Not Found", Result: new { }));

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
            SignUpResponse result = await _account.SignUpAsync(signUp);

            switch (result)
            {
                case SignUpResponse.Success:
                    return Ok((Id: 0, Title: "Success Go To Active Account", Result: new { }));
                case SignUpResponse.Exception:
                    return Ok((Id: -2, Title: "Exception", Result: new { }));
                case SignUpResponse.UserAlreadyExist:
                    return Ok((Id: -3, Title: "User Already Exist", Result: new { }));

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
                    return Ok((Id: 0, Title: "User Actived", Result: result.Success));
                case ActivationResponseEn.UserNotFound:
                    return Ok((Id: -1, Title: "UserNotFound", Result: new { }));
                case ActivationResponseEn.WrongActiveCode:
                    return Ok((Id: -3, Title: "Wrong ActiveCode", Result: new { }));
                case ActivationResponseEn.Exception:
                    return Ok((Id: -3, Title: "Exception", Result: new { }));

                default:
                    goto case ActivationResponseEn.Exception;
            }
        }

        #endregion

        #region --Recovery Password--

        //public async Task<IActionResult> RecoveyPassword(RecoveryPasswordViewModel recoveryPassword)
        //{
        //    return Ok();
        //}

        //public async Task<IActionResult> SetPassword(ChangePasswordViewModel changePassword)
        //{
        //    return Ok();
        //}

        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            var result = await _account.RequestChangePasswordAsync(changePassword, HttpContext.Request.Headers);
            switch (result)
            {
                case ChangePasswordResponse.Success:
                    return Ok((Id: 0, Title: "Success", Result: new { }));
                case ChangePasswordResponse.UserNotFound:
                    return Ok((Id: -1, Title: "User Not Found", Result: new { }));
                case ChangePasswordResponse.Exception:
                    return Ok((Id: -2, Title: "Exception", Result: new { }));
                case ChangePasswordResponse.WrongOldPassword:
                    return Ok((Id: -3, Title: "Wrong Password", Result: new { }));
                default:
                    goto case ChangePasswordResponse.Exception;
            }
        }

        #endregion
    }
}
