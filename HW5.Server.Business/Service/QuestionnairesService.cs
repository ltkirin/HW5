using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Business.Interfaces;
using HW5.Server.Business.Util;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Server.Business.Service
{
    public class QuestionnairesService : ServiceBase, IQuestionnairesService
    {
        public QuestionnairesService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<QuestionnaireFullModel>> CreateQuestionnaire(CreateQuestionnaireRequest request)
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
                return Response<QuestionnaireFullModel>.Ok(ModelConverter.GetQuestionnaireFullModel(questionnaire));


            }
            catch (Exception e)
            {
                return Response<QuestionnaireFullModel>.Failed(e.Message);
            }


        }

        public async Task<Response<QuestionnaireFullModel>> UpdateQuestionnaire(UpdateQuestionnaireRequest request)
        {
            var quest = await context.Questionnaires.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);
            if(!(await context.Clients.AnyAsync(x => !x.IsDeleted && x.Id == request.ClientId)))
            {
                return Response<QuestionnaireFullModel>.NotFound($"Client with Id {request.ClientId} Not found");
            }
            if(!(await context.Operators.AnyAsync(x => !x.IsDeleted && x.Id == request.OperatorId)))
            {
                return Response<QuestionnaireFullModel>.NotFound($"Operator with Id {request.OperatorId} Not found");
            }
            if (quest != null)
            {
                quest.ClientId = request.ClientId;
                quest.OperatorId = request.OperatorId;
                quest.ClientIncome = request.ClientIncome;
                quest.PaymentAbiliry = request.PaymentAbiliry;
                quest.CreditsCount = request.CreditsCount;
                quest.DepositesCount = request.DepositesCount;
                await context.SaveChangesAsync();
                return Response<QuestionnaireFullModel>.Ok(ModelConverter.GetQuestionnaireFullModel(quest));

            }
            else
            {
                return Response<QuestionnaireFullModel>.NotFound($"Questionnaire with Id {request.Id} Not found");
            }

        }
       

        public async Task<Response> DeleteQuestionnaire(int questionnaireId) => await Delete<Questionnaire>(questionnaireId);

        public async Task<Response<IList<QuestionnaireListModel>>> GetQuestionnaires(GetListRequest request)
              => Response<IList<QuestionnaireListModel>>.Ok(ModelConverter.GetQuestionnaireListModels(await GetEntities<Questionnaire>(request))).SetTotalReturn(await GetCount<Questionnaire>());
        public async Task<Response<QuestionnaireFullModel>> GetQuestionnaireDetails(int id, bool includeOwners)
        {
            var query = context.Questionnaires.AsQueryable().Where(x => x.Id == id && !x.IsDeleted);
            if (includeOwners)
            {
                query = query.Include(x => x.Operator);
                query = query.Include(x => x.Client);
            }
            var searchResult = await query.ToArrayAsync();
            if (searchResult.Any())
            {
                return Response<QuestionnaireFullModel>.Ok(ModelConverter.GetQuestionnaireFullModel(searchResult.First()));
            }
            else
            {
                return Response<QuestionnaireFullModel>.NotFound($"Questionnaire with Id {id} Not found");
            }

        }
    }
}
