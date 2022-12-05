using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class Report
    {
        public int OperatorId { get; set; } 
        public string OperatorFullName { get; set; }
        public string OperatorJobTitle { get; set; }

        public int QuestionnairesCount { get; set; }
    }
}
