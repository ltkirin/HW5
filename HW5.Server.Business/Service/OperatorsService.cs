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

namespace HW5.Server.Business.Service
{
    public class OperatorsService : ServiceBase, IOperatorsService
    {
        public OperatorsService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<Operator>> UpdateOperator(UpdateOperatorRequest request)
        {
            var oper = await context.Operators.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);
            if (oper != null)
            {
                oper.FirstName = request.FirstName;
                oper.LastName = request.LastName;
                oper.MiddleName = request.MiddleName;
                oper.BirthDate = request.BirthDate;
                oper.PhoneNumber = request.PhoneNumber;
                oper.JobTitle = request.JobTitle;
                oper.WorkExperience = request.WorkExperience;
                await context.SaveChangesAsync();
                return Response<Operator>.Ok(oper);

            }
            else
            {
                return Response<Operator>.NotFound($"Operator with Id {request.Id} Not found");
            }

        }
        public async Task<Response<Operator>> CreateOperator(CreateOperatorRequest request)
        {
            try
            {
                var oper = request.Adapt<Operator>();
                await context.Set<Operator>().AddAsync(oper);
                await context.SaveChangesAsync();
                return Response<Operator>.Ok(oper);


            }
            catch (Exception e)
            {
                return Response<Operator>.Failed(e.Message);
            }


        }

        public async Task<Response> DeleteOperator(int operatorId) => await Delete<Operator>(operatorId);

        public async Task<Response<IList<Operator>>> GetOperators(GetListRequest request) => await GetEntities<Operator>(request);
        public async Task<Response<Operator>> GetOperatorDetails(int id, bool includeReposrts)
        {
            var query = context.Operators.AsQueryable().Where(x => x.Id == id && !x.IsDeleted);
            if (includeReposrts)
            {
                query = query.Include(x => x.Questionnaires.Where(x => !x.IsDeleted));
            }
            var searchResult = await query.ToArrayAsync();
            if (searchResult.Any())
            {
                return Response<Operator>.Ok(searchResult.First());
            }
            else
            {
                return Response<Operator>.NotFound($"Operator with Id {id} Not found");
            }

        }



    }
}
