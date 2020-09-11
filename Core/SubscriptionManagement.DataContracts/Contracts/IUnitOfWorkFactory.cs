﻿namespace SubscriptionManagement.DataContracts.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        void Rollback();
    }
}