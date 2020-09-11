using System;
using System.Collections.Generic;
using System.Linq;
using CoreFlow.Core.HttpContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

using SubscriptionManagement.Core.HttpContext;

namespace CoreFlow.Core.Extensions
{
    public static class FilterContextExtensions
    {

        public static string GetFromClaims(this IHttpContextAccessor httpContextAccessor, string claimType)
        {
            return httpContextAccessor.HttpContext?.User?.Claims.Where(c => c.Type == claimType)
                .Select(c => c.Value).FirstOrDefault();
        }
    }
}
