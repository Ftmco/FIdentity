using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Services.Repository;
using Services.Services.Srevices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSI.Server.Pages
{
    public class IndexModel : PageModel
    {
        #region __Models__

        public OwnerInfoViewModel OwnerInfo { get; set; }

        public IEnumerable<Apps> AppInfo { get; set; }

        #endregion

        #region __Depdency__

        private readonly ILogger<IndexModel> _logger;

        private IUnitOfWork<FIdentityContext> _repository;

        private IOwnerManager _owner;

        private IAccountManager _account;

        private IAppManager _app;

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
    }
}
