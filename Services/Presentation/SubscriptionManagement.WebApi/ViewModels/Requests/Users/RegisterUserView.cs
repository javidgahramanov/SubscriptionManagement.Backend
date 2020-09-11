



using SubscriptionManagement.Core.Enums;

namespace SubscriptionManagement.WebApi.ViewModels.Requests.Users
{
    public class RegisterUserView
    { public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public UserRoleType UserRole { get; set; }
    }
}
