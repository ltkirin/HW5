using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class OperatorFullModel : EntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int JobTitleIndex { get; set; }
        public int WorkExperience { get; set; }
        public IList<QuestionnaireListModel> Questionnaires { get; set; }
    }
}
