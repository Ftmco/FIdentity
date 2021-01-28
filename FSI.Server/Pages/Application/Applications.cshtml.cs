using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Http;
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
            IRequestCookieCollection cookies = HttpContext.Request.Cookies;
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

        public async Task<IActionResult> OnGetDelete(Guid id)
        {
            var cookies = HttpContext.Request.Cookies;
            if (await _account.IsLoginAsync(cookies))
            {
                DeleteAppStatus result = await _app.DeleteAppAsync(HttpContext.Request.Cookies, id);

                switch (result)
                {
                    case DeleteAppStatus.Success:
                        return RedirectToPage("Index");
                    case DeleteAppStatus.AppNotFound:
                        {
                            TempData["Err"] = "404 Application Not Found";
                            return RedirectToPage("Index");
                        }
                    case DeleteAppStatus.AccessDenied:
                        {
                            TempData["Err"] = "403 Access Foriben";
                            return RedirectToPage("Index");
                        }
                    case DeleteAppStatus.Exception:
                        {
                            TempData["Err"] = "Try Again";
                            return RedirectToPage("Index");
                        }
                    default:
                        goto case DeleteAppStatus.Exception;
                }
            }
            else
                return RedirectToPage("/Account/Login");
        }
    }
}
