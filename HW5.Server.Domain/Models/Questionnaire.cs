using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Domain.Models
{
    public class Questionnaire : EntityBase
    { 
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public double ClientIncome { get; set; }
        public double PaymentAbiliry { get; set; }
        public int CreditsCount { get; set; }
        public int DepositesCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
