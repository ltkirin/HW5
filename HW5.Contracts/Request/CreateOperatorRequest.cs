using HW5.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Models
{
    public class CreateOperatorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public uint PhoneNumber { get; set; }
        public OperatorsJobTitle JobTitle { get; set; }
        public int WorkExperience { get; set; }
    }
}
