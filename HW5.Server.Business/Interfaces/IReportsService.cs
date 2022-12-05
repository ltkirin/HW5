using HW5.Contracts.Request;
using HW5.Contracts.Response;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IReportsService
    {
        Task<Response<Report>> GenerateReport(ReportRequest request);
    }
}