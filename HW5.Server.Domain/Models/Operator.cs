using HW5.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Domain.Models
{
    public class Operator : Person
    {
        public OperatorsJobTitle JobTitle { get; set; }
        public int WorkExperience { get; set; }
        public HashSet<Questionnaire> Questionnaires { get; set; }
    }
}
