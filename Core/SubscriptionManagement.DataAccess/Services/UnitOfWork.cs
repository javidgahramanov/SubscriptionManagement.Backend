using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using SubscriptionManagement.Core.HttpContext;
using SubscriptionManagement.DataContracts.Contracts;
using SubscriptionManagement.Domains.Entities.Base;

namespace SubscriptionManagement.DataAccess.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContextManager;

        public UnitOfWork(IDbContextFactory dbContextFactory, IRequestContextProvider httpRequestProvider)
        {
            _dbContextManager = dbContextFactory.GetContext();

            var userName = httpRequestProvider.Context.UserName;

            _dbContextManager.ChangeTracker.Tracked += (obj, arg) =>
            {
                var state = arg.Entry.State;
                var entity = arg.Entry.Entity;

                if (state != EntityState.Added) 
                    return;

                if (entity is BaseEntity baseEntity)
                {
                    baseEntity.Id = Guid.NewGuid();
                }

                var currentDateTime = DateTime.UtcNow;

                if (entity is AuditCreationEntity auditCreationEntity)
                {
                    auditCreationEntity.CreatedAt = currentDateTime;
                    auditCreationEntity.CreatedBy = userName;
                }

                if (!(entity is AuditEntity auditEntity)) 
                    return;

                auditEntity.ModifiedAt = currentDateTime;
                auditEntity.ModifiedBy = userName;
            };

            _dbContextManager.ChangeTracker.StateChanged += (obj, arg) =>
            {
                var state = arg.Entry.State;
                var entity = arg.Entry.Entity;

                if (state != EntityState.Modified || !(entity is AuditEntity auditEntity)) 
                    return;

                auditEntity.ModifiedAt = DateTime.UtcNow;
                auditEntity.ModifiedBy = userName;
            };
        }

        public int Commit()
        {
            return _dbContextManager.ChangeTracker.HasChanges() ? _dbContextManager.SaveChanges() : 0;
        }

        public async Task<int> CommitAsync()
        {
            if (_dbContextManager.ChangeTracker.HasChanges())
            {
                return await _dbContextManager.SaveChangesAsync();
            }

            return 0;
        }

        ~UnitOfWork()
        {
            Dispose();
        }

        public void Dispose()
        {

        }
    }
}