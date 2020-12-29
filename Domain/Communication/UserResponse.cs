using SCIMServer.Domain.Models;

namespace SCIMServer.Domain.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; protected set; }

        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        public UserResponse(User user) : this(true, string.Empty, user)
        { }

        public UserResponse(string message) : this(false, message, null)
        { }
    }
}
