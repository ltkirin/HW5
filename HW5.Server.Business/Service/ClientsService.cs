using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Business.Interfaces;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Business.Service
{
    internal class ClientsService : ServiceBase, IClientService
    {
        public ClientsService(PgSqlApplicationContext context) : base(context)
        {
        }

        public async Task<Response<Client>> CreateClient(CreateClientRequest command)
        {
            try
            {
                var client = command.Adapt<Client>();
                await context.Set<Client>().AddAsync(client);
                await context.SaveChangesAsync();
                return Response<Client>.Ok(client);


            }
            catch (Exception e)
            {
                return Response<Client>.Failed(e.Message);
            }


        }
    }
}
