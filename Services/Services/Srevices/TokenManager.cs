using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Generic.UnitOfWork;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class TokenManager : ITokenManager
    {
        #region ::Dependency::

        private readonly IUnitOfWork<FIdentityContext> _repository;

        public TokenManager()
        {
            _repository = new UnitOfWork<FIdentityContext>();
        }

        #endregion

        public async Task<Tokens> GetTokenByValueAsync(string tokenValue)
        {
            return await Task.Run(async () => await _repository.TokensRepository.GetFirstOrDefaultAsync(t => t.TokenValue == tokenValue));
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
