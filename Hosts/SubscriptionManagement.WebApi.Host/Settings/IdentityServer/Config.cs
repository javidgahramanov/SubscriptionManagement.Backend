using System.Collections.Generic;
using System.Security.Claims;

using IdentityServer4;
using IdentityServer4.Models;

using SubscriptionManagement.Core.Configs;

namespace SubscriptionManagement.WebApi.Host.Settings.IdentityServer
{
    public class Config
    {
        private readonly IdentitySettings _identitySettings;

        public Config(IdentitySettings identitySettings)
        {
            _identitySettings = identitySettings;
        }

        public IEnumerable<IdentityResource> Ids =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new List<string> { "role" })
         
            };


        public IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource(_identitySettings.Audience, "Subscription Management WebApi")
            };

        public IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = _identitySettings.ClientId,
                    ClientSecrets = {new Secret(_identitySettings.Secret.Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 900,

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        _identitySettings.Audience
                    },
                    AllowedCorsOrigins=new[]{"http://localhost:4200"},
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AbsoluteRefreshTokenLifetime = 7200,
                    SlidingRefreshTokenLifetime = 900,
                    RefreshTokenExpiration = TokenExpiration.Sliding,

                }
            };
    }
}
