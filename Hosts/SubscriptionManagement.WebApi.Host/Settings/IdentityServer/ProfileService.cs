using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;

using SubscriptionManagement.Service.Contracts.Services;

namespace SubscriptionManagement.WebApi.Host.Settings.IdentityServer
{
    public class ProfileService : IProfileService
    {
        private readonly IUserService _userService;

        public ProfileService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userName = context.Subject.FindFirst(JwtClaimTypes.Subject)?.Value;

            if (string.IsNullOrWhiteSpace(userName)) 
                return;

            var userClaims = await _userService.GetClaimsForUser(userName);

            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, userName));
            identity.AddClaims(userClaims);

            var claims = (new ClaimsPrincipal(identity)).Claims;

            if (context.RequestedClaimTypes != null && context.RequestedClaimTypes.Any())
            {
                claims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
            }

            context.IssuedClaims = claims.ToList();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }
    }
}