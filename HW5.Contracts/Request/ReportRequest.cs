using System;

namespace HW5.Contracts.Request
{
    public class ReportRequest
    {
        public int OperatorId { get; set; }
        public DateTime FromTime { get; set; } = DateTime.MinValue;
        public DateTime UntilTime { get; set; } = DateTime.MaxValue;
    }
}
