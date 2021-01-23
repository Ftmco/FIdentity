using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Services.Repository;
using Services.Services.Srevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSI.Server.Pages
{
    public class IndexModel : PageModel
    {
        public OwnerInfoViewModel OwnerInfo { get; set; }

        #region __Depdency__

        private readonly ILogger<IndexModel> _logger;

        private IUnitOfWork<FIdentityContext> _repository;

        private IOwnerManager _owner;

        #endregion

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _repository = new UnitOfWork<FIdentityContext>();
            _owner = new OwnerManger();
        }

        public void OnGet()
        {
            ownerInfo = _owner.GetOwnerInfoAsync(HttpContext.Request.Headers).Result;
        }
    }
}
