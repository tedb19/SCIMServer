namespace SCIMServer.Domain.Models
{
    public class Email
    {
        public int Id { get; set; }
        public EType Type { get; set; }
        public string Value { get; set; }
        public bool Primary { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
