using System.ComponentModel.DataAnnotations;

namespace HW5.Contracts.Request
{
    public class UpdateOperatorRequest : CreateOperatorRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
