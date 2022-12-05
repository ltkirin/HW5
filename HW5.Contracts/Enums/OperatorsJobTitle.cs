using System.ComponentModel;

namespace HW5.Contracts.Enums
{
    public enum OperatorsJobTitle
    {
        [Description("Стажер")]
        Trainee = 0,
        [Description("Опеартор")]
        Operator = 1,
        [Description("Ст. оператор")]
        SeniorOperator = 2,
        [Description("Менеджер")]
        Manager = 3
    }
}
