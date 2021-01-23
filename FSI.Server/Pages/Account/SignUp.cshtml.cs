using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FSI.Server.Pages.Account
{
    public class SignInModel : PageModel
    {
        #region __Dependecy__

        private IAccountManager _account;

        public SignInModel()
        {
            _account = new AccountManager();
        }

        #endregion

        public SignupViewModel Signup { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSignup(SignupViewModel signup)
        {
            var result = await _account.SignUpAsync(signup, HttpContext.Request.Headers);

            switch (result)
            {
                case SignUpResponse.Success:
                    return RedirectToPage("/Login");
                case SignUpResponse.Exception:
                    {
                        ViewData["Err"] = "Try Again";
                        return Page();
                    }
                case SignUpResponse.UserAlreadyExist:
                    {
                        ViewData["Err"] = "User Already Exist";
                        return Page();
                    }
                case SignUpResponse.AppNotFound:
                    {
                        ViewData["Err"] = "User Already Exist";
                        return Page();
                    }
                case SignUpResponse.AppActivent:
                    {
                        ViewData["Err"] = "User Already Exist";
                        return Page();
                    }
                case SignUpResponse.AppIsntForYou:
                    {
                        ViewData["Err"] = "User Already Exist";
                        return Page();
                    }
                default:
                    goto case SignUpResponse.Exception;
            }
        }
    }
}
