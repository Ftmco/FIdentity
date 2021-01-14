using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class TokenManager : ITokenManager, IDisposable
    {
        #region ::Dependency::

        private readonly FIdentityContext _db;

        public TokenManager(FIdentityContext db)
        {
            _db = db;
        }

        #endregion

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }

        public async Task<Tokens> GetTokenByValueAsync(string tokenValue)
        {
            return await Task.Run(async () => await _db.Tokens.FirstOrDefaultAsync(t => t.TokenValue == tokenValue));
        }

        public async Task<Tokens> GetTokenFromCookiesAsync(IRequestCookieCollection cookie)
        {
            return await Task.Run(async () => await GetTokenByValueAsync(cookie["Token"]));
        }

        public async Task<Tokens> GetTokenFromHeaderAsync(IHeaderDictionary header)
        {
            return await Task.Run(async () => await GetTokenByValueAsync(header["Token"]));
        }
    }
}
