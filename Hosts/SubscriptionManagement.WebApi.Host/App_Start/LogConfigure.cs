using Microsoft.Extensions.Configuration;

namespace CoreFlow.WebApi.Host.App_Start
{
    public static class LogConfigure
    {
        public static void CreateLogger(IConfiguration config)
        {
#if DEBUG
            
#else
            
#endif
        }
    }
}
