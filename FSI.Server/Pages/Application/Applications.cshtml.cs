using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Repository;
using Services.Services.Srevices;

namespace FSI.Server.Pages.Application
{
    public class ApplicationsModel : PageModel
    {
        #region __Models__

        /// <summary>
        /// Owner Info Model
        /// </summary>
        public OwnerInfoViewModel OwnerInfo { get; set; }

        /// <summary>
        /// Applications Info
        /// </summary>
        public IEnumerable<Apps> AppInfo { get; set; }

        /// <summary>
        /// Application Title For Add New App
        /// </summary>
        [Display(Name = "App Title")]
        [Required]
        public string AppTitle { get; set; }

        /// <summary>
        /// Check Current User Is Owner 
        /// </summary>
        public bool IsOwner => OwnerInfo != null;

        #endregion

        #region __Dependency__

        /// <summary>
        /// Repository Controller Services
        /// </summary>
        private readonly IUnitOfWork<FIdentityContext> _repository;

        /// <summary>
        /// Owner Services
        /// </summary>
        private readonly IOwnerManager _owner;

        /// <summary>
        /// Account Services
        /// </summary>
        private readonly IAccountManager _account;

        /// <summary>
        /// Applications Services
        /// </summary>
        private readonly IAppManager _app;

        public ApplicationsModel()
        {
            _repository = new UnitOfWork<FIdentityContext>();
            _owner = new OwnerManger();
            _account = new AccountManager();
            _app = new AppManager();
        }

        #endregion

        public async Task<IActionResult> OnGet()
        {
            var cookies = HttpContext.Request.Cookies;
            if (await _account.IsLoginAsync(cookies))
            {
                OwnerInfo = await _owner.GetOwnerInfoAsync(cookies);
                AppInfo = await _app.GetOwnerAppsAsync(cookies);
                return Page();
            }
            else
                return RedirectToPage("/Account/Login");
        }
    }
}
