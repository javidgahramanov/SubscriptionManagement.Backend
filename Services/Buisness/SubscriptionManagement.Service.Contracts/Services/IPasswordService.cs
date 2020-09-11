using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Service.Contracts.Services
{
    public interface IPasswordService
    {
        (string password, string hash) GeneratePassword(string password);
        bool IsHashValid(string password, string hashValue);
    }
}
