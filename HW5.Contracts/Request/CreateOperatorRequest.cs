using HW5.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Models
{
    public class CreateOperatorRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public ulong PhoneNumber { get; set; }
        [Required]
        public OperatorsJobTitle JobTitle { get; set; }
        [Required]
        public int WorkExperience { get; set; }
    }
}
