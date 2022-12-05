using System.ComponentModel.DataAnnotations;

namespace HW5.Contracts.Request
{
    public class UpdateQuestionnaireRequest : CreateQuestionnaireRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
