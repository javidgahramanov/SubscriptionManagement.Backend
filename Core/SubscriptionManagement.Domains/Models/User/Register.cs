

using SubscriptionManagement.Core.Enums;

using System;

namespace SubscriptionManagement.Domains.Models.User
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoleType UserRole { get; set; }
    }
}