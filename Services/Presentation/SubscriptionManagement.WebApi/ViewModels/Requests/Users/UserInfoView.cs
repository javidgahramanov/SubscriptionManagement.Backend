using SubscriptionManagement.Core.Enums;

using System;

namespace SubscriptionManagement.WebApi.ViewModels.Requests.Users
{
    public class UserInfoView
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid SubscriptionId { get; set; }
        public UserRoleType UserRole { get; set; }
    }
}
