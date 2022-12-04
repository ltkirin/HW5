using HW5.Contracts.Models;
using HW5.Contracts.Response;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Response> DeleteOperator(int operatorId)
        {
            try
            {
                var oper = await GetEntitiesQuerable<Operator>().FirstOrDefaultAsync(x => x.Id == operatorId && !x.IsDeleted);
                if (oper != null)
                {
                    oper.IsDeleted = true;
                    await context.SaveChangesAsync();
                    return Response.Ok();
                }
                else
                {
                    return Response.NotFound($"Opertaor with Id {operatorId} is not found or already deleted"); ;
                }
            }
            catch (Exception e)
            {
                return Response.Failed(e.Message);
            }
        }

        public async Task<Response<IList<Operator>>> GetOperators(GetListRequest request)
        {
            try
            {
                var querable = GetEntitiesQuerable<Operator>();
                var count = await querable.CountAsync();
                var operators = await querable
                    .AsNoTracking()
                    .Skip(request.PageCount * request.PageSize)
                    .Take(request.PageSize)
                    .ToArrayAsync();

                var result = Response<IList<Operator>>.Ok(operators);
                result.Metadata.Add("Total", $"{count}");
                return result;
            }
            catch (Exception e)
            {
                return Response<IList<Operator>>.Failed(e.Message);
            }
        }


    }
}
