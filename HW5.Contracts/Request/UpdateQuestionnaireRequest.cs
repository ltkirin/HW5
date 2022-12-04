using HW5.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HW5.Contracts.Request
{
    public class UpdateQuestionnaireRequest : CreateQuestionnaireRequest, IUpdateRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
