using System.ComponentModel.DataAnnotations;

namespace HW5.Contracts.Request
{
    public class GetListRequest
    {
        [Required]
        public int PageCount { get; set; } = 0;
        [Required]
        public int PageSize { get; set; } = 10;
    }
}
