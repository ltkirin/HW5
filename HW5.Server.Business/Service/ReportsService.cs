using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Business.Interfaces;
using HW5.Server.Business.Util;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Server.Business.Service
{
    internal class ReportsService : ServiceBase, IReportsService
    {
        public ReportsService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<Report>> GenerateReport(ReportRequest request)
        {
            try
            {
                var oper = await context
                    .Set<Operator>()
                    .Where(x => !x.IsDeleted && x.Id == request.OperatorId)
                            .Include(x => x.Questionnaires)
                    .AsQueryable()
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                if (oper == null)
                {
                    return Response<Report>.NotFound($"Operator with Id {request.OperatorId} Not found");
                }
                var result = new Report
                {
                    OperatorId = oper.Id,
                    OperatorFullName = ModelConverter.GetFullName(oper),
                    OperatorJobTitle = oper.JobTitle.GetDisplayName(),
                    QuestionnairesCount = oper.Questionnaires.Where(x => x.CreationDate >= request.FromTime && x.CreationDate <= request.UntilTime).Count()
                };
                return Response<Report>.Ok(result);
            }
            catch (Exception e)
            {
                return Response<Report>.Failed(e.Message);
            }
        }
    }
}
