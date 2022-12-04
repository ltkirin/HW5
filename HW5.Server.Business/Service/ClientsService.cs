using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Business.Interfaces;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Response> DeleteClient(int operatorId) => await Delete<Client>(operatorId);
        public async Task<Response<Client>> UpdateClient(UpdateClientRequest request)
        {
            var client = await context.Clients.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);
            if (client != null)
            {
                client.FirstName = request.FirstName;
                client.LastName = request.LastName;
                client.MiddleName = client.MiddleName;
                client.BirthDate = request.BirthDate;
                client.PhoneNumber = request.PhoneNumber;
                await context.SaveChangesAsync();
                return Response<Client>.Ok(client);

            }
            else
            {
                return Response<Client>.NotFound($"Client with Id {request.Id} Not found");
            }

        }
        public async Task<Response<IList<Client>>> GetClients(GetListRequest request) => await GetEntities<Client>(request);
        public async Task<Response<Client>> GetClientDetails(int id, bool includeReposrts)
        {
            var query = context.Clients.AsQueryable().Where(x => x.Id == id && !x.IsDeleted);
            if (includeReposrts)
            {
                query = query.Include(x => x.Questionnaires);
            }
            var searchResult = await query.ToArrayAsync();
            if (searchResult.Any())
            {
                return Response<Client>.Ok(searchResult.First());
            }
            else
            {
                return Response<Client>.NotFound($"Client with Id {id} Not found");
            }

        }
    }
}
