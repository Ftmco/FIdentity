using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Repository;
using Services.Services.Srevices;

namespace FSI.Server.Pages.Application
{
    public class AppUsersModel : PageModel
    {
        #region __Models__

        /// <summary>
        /// Application Users Model
        /// </summary>
        public IEnumerable<ApplicationUsersViewModel> Users { get; set; }

        #endregion

        #region __Depdency__

        /// <summary>
        /// Application Services
        /// </summary>
        private readonly IAppManager _app;

        /// <summary>
        /// Account Services
        /// </summary>
        private readonly IAccountManager _account;

        public AppUsersModel()
        {
            _app = new AppManager();
            _account = new AccountManager();
        }

        #endregion


        public async Task<IActionResult> OnGet(string token)
        {
            Users = await _app.GetAppUsersViewModelAsync(token.ToString(), 0, 10);
            return Page();
        }
    }
}
