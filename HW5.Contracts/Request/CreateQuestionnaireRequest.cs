namespace HW5.Contracts.Request
{
    public class CreateQuestionnaireRequest
    {
        public int ClientId { get; set; }
        public int OperatorId { get; set; }
        public double ClientIncome { get; set; }
        public double PaymentAbiliry { get; set; }
        public int CreditsCount { get; set; }
        public int DepositesCount { get; set; }
    }
}
