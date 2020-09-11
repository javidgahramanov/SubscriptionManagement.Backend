namespace SubscriptionManagement.Core.HttpContext
{
    public interface IRequestContextProvider
    {
        IRequestContext Context { get; }
    }
}
