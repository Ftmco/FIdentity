using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FSI.Server.Pages
{
    public class LoginModel : PageModel
    {
        #region __Depdency__

        /// <summary>
        /// Account Services 
        /// </summary>
        private IAccountManager _account;

        public LoginModel()
        {
            _account = new AccountManager();
        }

        #endregion

        public LoginViewModel Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin(LoginViewModel login)
        {
            LoginResponse result = await _account.LoginAsync(login, 20, HttpContext);

            switch (result.Status)
            {
                case LoginStatus.Success:
                    {
                        if (!login.RememberMe)
                        {
                            HttpContext.Response.Cookies.Append(result.Success.Key, result.Success.Value);
                            return RedirectToPage("/Index");
                        }
                        else
                        {
                            HttpContext.Response.Cookies.Append(result.Success.Key, result.Success.Value, new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(20) });
                            return RedirectToPage("/Index");
                        }
                    }
                case LoginStatus.Exception:
                    {
                        ViewData["Err"] = "Try Again";
                        return Page();
                    }
                case LoginStatus.WrongPassword:
                    {
                        ViewData["Err"] = "Wrong Pasword";
                        return Page();
                    }
                case LoginStatus.UserNotFound:
                    {
                        ViewData["Err"] = "Not Found User";
                        return Page();
                    }
                default:
                    goto case LoginStatus.UserNotFound;
            }
        }
    }
}
