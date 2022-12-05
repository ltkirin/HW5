using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class OperatorListModel : EntityModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int JobTitleIndex { get; set; }
        public int WorkExperience { get; set; }
    }
}
