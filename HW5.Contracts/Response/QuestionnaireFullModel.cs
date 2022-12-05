using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Contracts.Response
{
    public class QuestionnaireFullModel : EntityModel
    {
        public int ClientId { get; set; }
        public int OperatorId { get; set; }
        public string ClientFullName { get; set; }
        public string OperatorFullName { get; set; }
        public double ClientIncome { get; set; }
        public double PaymentAbiliry { get; set; }
        public int CreditsCount { get; set; }
        public int DepositesCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
