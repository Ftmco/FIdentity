using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Services.Repository;
using Services.Services.Srevices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FSI.Server.Pages
{
    public class IndexModel : PageModel
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

        #region __Depdency__

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

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

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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

        public async Task<IActionResult> OnPostCreateApp(string AppTitle)
        {
            CreateAppResponse result = await _app.CreateAppAsync(AppTitle, HttpContext.Request.Cookies);

            switch (result)
            {
                case CreateAppResponse.Success:
                    {
                        return RedirectToPage("Index");
                    }
                case CreateAppResponse.OwnerNotFound:
                    {
                        TempData["Err"] = "You are Not an Owner";
                        return RedirectToPage("Index");
                    }
                case CreateAppResponse.Exception:
                    {
                        TempData["Err"] = "Try Again";
                        return RedirectToPage("Index");
                    }
                default:
                    goto case CreateAppResponse.Exception;
            }
        }

        public async Task<IActionResult> OnPostOwnerShipRequest(string coName, IFormFile coImage)
        {
            var cookies = HttpContext.Request.Cookies;
            if (await _account.IsLoginAsync(cookies))
            {
                OwnerShipRequestStatus result = await _owner.OwnerRequestAsync(cookies, coName, coImage);

                switch (result)
                {
                    case OwnerShipRequestStatus.Success:
                        {
                            TempData["Err"] = "Now You Are Owership";
                            return RedirectToPage("Index");
                        }
                    case OwnerShipRequestStatus.UserNotfound:
                        return RedirectToPage("/Account/Login");
                    case OwnerShipRequestStatus.Exception:
                        {
                            TempData["Err"] = "Try Again";
                            return RedirectToPage("Index");
                        }
                    case OwnerShipRequestStatus.CoExist:
                        {
                            TempData["Err"] = "There is currently an owner with current specifications";
                            return RedirectToPage("Index");
                        }
                    default:
                        goto case OwnerShipRequestStatus.Exception;
                }
            }
            else
                return RedirectToPage("/Account/Login");
        }
    }
}
