using SCIMServer.Domain.Models;
namespace SCIMServer.Domain.Communication
{
    public class GroupResponse : BaseResponse
    {
        public Group Group { get; protected set; }

        private GroupResponse(bool success, string message, Group group) : base(success, message)
        {
            Group = group;
        }

        public GroupResponse(Group group) : this(true, string.Empty, group)
        { }

        public GroupResponse(string message) : this(false, message, null)
        { }
    }
}
