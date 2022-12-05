using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class QuestionnaireListModel : EntityModel
    {
        public string ClientFullName { get; set; }
        public string OperatorFullName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
