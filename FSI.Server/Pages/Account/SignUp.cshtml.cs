using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
