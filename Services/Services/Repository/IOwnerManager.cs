using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Repository
{
    public interface IOwnerManager
    {
        Task<OwnerInfoViewModel> GetOwnerInfoAsync(Guid userId);
        Task<OwnerInfoViewModel> GetOwnerInfoAsync(IHeaderDictionary header);
        Task<OwnerInfoViewModel> GetOwnerInfoAsync(IRequestCookieCollection cookie);
    }
}
