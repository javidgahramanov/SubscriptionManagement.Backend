using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SubscriptionManagement.Core.HttpContext;

namespace SubscriptionManagement.WebApi.Endpoints.Base
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly IRequestContextProvider RequestContextProvider;

        public BaseController(IMapper mapper, IRequestContextProvider requestContextProvider)
        {
            Mapper = mapper;
            RequestContextProvider = requestContextProvider;
        }
    }
}
