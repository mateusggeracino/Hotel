namespace Hotel.Domain.Models
{
    /// <summary>
    /// Entidade responsável por conter as propriedades de um cliente.
    /// </summary>
    public class ClientEntity : Entity
    {
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}