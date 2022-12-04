using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Business.Interfaces;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using Mapster;
using System;
using System.Threading.Tasks;

namespace HW5.Server.Business.Service
{
    public class QuestionnairesService : ServiceBase, IQuestionnairesService
    {
        public QuestionnairesService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<Questionnaire>> CreateQuestionnaire(CreateQuestionnaireRequest request)
        {
            try
            {
                var client = await context.Set<Client>().FindAsync(request.ClientId);
                if (client == null)
                {
                    Response<Questionnaire>.NotFound($"Client with Id {request.ClientId} not found");
                }
                var oper = await context.Set<Operator>().FindAsync(request.OperatorId);
                if (oper == null)
                {
                    Response<Questionnaire>.NotFound($"Operator with Id {request.OperatorId} not found");
                }

                var questionnaire = new Questionnaire()
                {
                    OperatorId = oper.Id,
                    ClientId = client.Id,
                    ClientIncome = request.ClientIncome,
                    PaymentAbiliry = request.PaymentAbiliry,
                    CreditsCount = request.CreditsCount,
                    DepositesCount = request.DepositesCount
                };


                await context.Set<Questionnaire>().AddAsync(questionnaire);
                await context.SaveChangesAsync();
                return Response<Questionnaire>.Ok(questionnaire);


            }
            catch (Exception e)
            {
                return Response<Questionnaire>.Failed(e.Message);
            }


        }
    }
}
