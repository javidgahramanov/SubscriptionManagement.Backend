using System;
using System.Collections.Generic;
using System.Linq;
using CoreFlow.Core.Extensions;
using IdentityModel;

using Microsoft.AspNetCore.Http;

using SubscriptionManagement.Core.Constants;
using SubscriptionManagement.Core.Enums;
using SubscriptionManagement.Core.HttpContext;

namespace CoreFlow.Core.HttpContext
{
    public class HttpRequestContext : BaseRequestContext
    {
        public List<string> UserPermissions { get; private set; }

        public HttpRequestContext(IHttpContextAccessor httpContextAccessor)
        {
            RequestId = Guid.NewGuid();

            if (httpContextAccessor.HttpContext?.User?.Identity == null || !httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return;

            UserName = GetUserFromRequest(httpContextAccessor);
            Role = GetRoleFromRequest(httpContextAccessor);
            SubscriptionId = GetSubscriptionFromContext(httpContextAccessor);
        }

        private string GetUserFromRequest(IHttpContextAccessor httpContextAccessor)
        {
            var userFromHeader = GetHeaderValues(httpContextAccessor, "X-User");
            var userFromIdentity = httpContextAccessor.HttpContext?.User?.Identity?.Name;

            var username = !string.IsNullOrEmpty(userFromHeader) ? userFromHeader : userFromIdentity;

            return username?.ToLower() ?? "anonymous";
        }


        private Guid GetSubscriptionFromContext(IHttpContextAccessor httpContextAccessor)
        {
            var companyId = httpContextAccessor.GetFromClaims(AppClaimTypes.SubscriptionId);

            Guid.TryParse(companyId, out var result);

            return result;
        }

        private UserRoleType GetRoleFromRequest(IHttpContextAccessor httpContextAccessor)
        {
            var role = httpContextAccessor.GetFromClaims(JwtClaimTypes.Role);
            return (UserRoleType)Enum.Parse(typeof(UserRoleType), role);
        }


        private string GetHeaderValues(IHttpContextAccessor httpContextAccessor, string header)
        {
            return httpContextAccessor
                .HttpContext?
                .Request?
                .Headers?
                .FirstOrDefault(x => x.Key == header)
                .Value;
        }
    }
}