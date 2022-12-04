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

namespace HW5.Server.Business.Service
{
    public class OperatorsService : ServiceBase, IOperatorsService
    {
        public OperatorsService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<Operator>> CreateOperator(CreateOperatorRequest command)
        {
            try
            {
                var oper = command.Adapt<Operator>();
                await context.Set<Operator>().AddAsync(oper);
                await context.SaveChangesAsync();
                return Response<Operator>.Ok(oper);


            }
            catch (Exception e)
            {
                return Response<Operator>.Failed(e.Message);
            }


        }
    }
}
