using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

using SubscriptionManagement.Service.Contracts.Services;

namespace SubscriptionManagement.WebApi.Host.Settings.IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;

        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var isValid = await _userService.IsPasswordValid(context.UserName, context.Password);

            if (!isValid)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid credentials.");
                return;
            }

            var claims = await _userService.GetClaimsForUser(context.UserName);

            context.Result = new GrantValidationResult(context.UserName, GrantType.ResourceOwnerPassword, claims);
        }
    }
}
