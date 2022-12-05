using HW5.Contracts.Response;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using HW5.Server.Business.Interfaces;
using HW5.Contracts.Request;
using Microsoft.EntityFrameworkCore;
using HW5.Server.Business.Util;

namespace HW5.Server.Business.Service
{
    public class OperatorsService : ServiceBase, IOperatorsService
    {
        public OperatorsService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<OperatorFullModel>> UpdateOperator(UpdateOperatorRequest request)
        {
            var oper = await context.Operators.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);
            if (oper != null)
            {
                oper.FirstName = request.FirstName;
                oper.LastName = request.LastName;
                oper.MiddleName = oper.MiddleName;
                oper.BirthDate = request.BirthDate;
                oper.PhoneNumber = request.PhoneNumber;
                oper.JobTitle = request.JobTitle;
                oper.WorkExperience = request.WorkExperience;
                await context.SaveChangesAsync();
                return Response<OperatorFullModel>.Ok(ModelConverter.GetOperatorFullModel(oper));

            }
            else
            {
                return Response<OperatorFullModel>.NotFound($"Operator with Id {request.Id} Not found");
            }

        }
        public async Task<Response<OperatorFullModel>> CreateOperator(CreateOperatorRequest request)
        {
            try
            {
                var oper = request.Adapt<Operator>();
                await context.Set<Operator>().AddAsync(oper);
                await context.SaveChangesAsync();
                return Response<OperatorFullModel>.Ok(ModelConverter.GetOperatorFullModel(oper));


            }
            catch (Exception e)
            {
                return Response<OperatorFullModel>.Failed(e.Message);
            }


        }

        public async Task<Response> DeleteOperator(int operatorId) => await Delete<Operator>(operatorId);

        public async Task<Response<IList<OperatorListModel>>> GetOperators(GetListRequest request)
              => Response<IList<OperatorListModel>>.Ok(ModelConverter.GetOperatorListModels(await GetEntities<Operator>(request))).SetTotalReturn(await GetCount<Operator>());
        public async Task<Response<OperatorFullModel>> GetOperatorDetails(int id, bool includeReposrts)
        {
            var query = context.Operators.AsQueryable().Where(x => x.Id == id && !x.IsDeleted);
            if (includeReposrts)
            {
                query = query.Include(x => x.Questionnaires);
            }
            var searchResult = await query.ToArrayAsync();
            if (searchResult.Any())
            {
                return Response<OperatorFullModel>.Ok(ModelConverter.GetOperatorFullModel(searchResult.First()));
            }
            else
            {
                return Response<OperatorFullModel>.NotFound($"Operator with Id {id} Not found");
            }

        }



    }
}
