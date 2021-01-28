using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Services.Repository;
using Services.Services.Srevices;
using System;
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
                return Page();
            }
            else
                return RedirectToPage("/Account/Login");
        }

       
    }
}
