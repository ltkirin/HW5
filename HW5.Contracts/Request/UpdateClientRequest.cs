using System.ComponentModel.DataAnnotations;

namespace HW5.Contracts.Request
{
    public class UpdateClientRequest : CreateClientRequest
    {
        [Required]
        public int Id { get; set ; }
    }
}
