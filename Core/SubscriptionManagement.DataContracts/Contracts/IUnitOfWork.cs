using System;
using System.Threading.Tasks;

namespace SubscriptionManagement.DataContracts.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
    }
}