using SCIMServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; protected set; }

        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        public UserResponse(User User) : this(true, string.Empty, User)
        { }

        public UserResponse(string message) : this(false, message, null)
        { }
    }
}
