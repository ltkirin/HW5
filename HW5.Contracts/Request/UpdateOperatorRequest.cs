using HW5.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Request
{
    public class UpdateOperatorRequest : CreateOperatorRequest, IUpdateRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
