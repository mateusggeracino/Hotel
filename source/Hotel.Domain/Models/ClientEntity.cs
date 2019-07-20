namespace Hotel.Domain.Models
{
    public class ClientEntity : Entity
    {
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}