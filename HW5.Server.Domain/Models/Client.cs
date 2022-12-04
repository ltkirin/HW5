using System.Collections.Generic;

namespace HW5.Server.Domain.Models
{
    public class Client : Person
    {
        public HashSet<Questionnaire> Questionnaires { get; set; }
    }
}
