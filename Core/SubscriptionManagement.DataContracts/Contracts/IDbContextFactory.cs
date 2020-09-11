using Microsoft.EntityFrameworkCore;

namespace SubscriptionManagement.DataContracts.Contracts
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
