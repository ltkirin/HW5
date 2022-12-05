using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Business.Service
{
    public abstract class ServiceBase
    {
        protected readonly PgSqlApplicationContext context;

        public ServiceBase(PgSqlApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Response> Delete<TEntity>(int operatorId) where TEntity : EntityBase
        {
            try
            {
                var oper = await GetEntitiesQuerable<TEntity>().FirstOrDefaultAsync(x => x.Id == operatorId && !x.IsDeleted);
                if (oper != null)
                {
                    oper.IsDeleted = true;
                    await context.SaveChangesAsync();
                    return Response.Ok();
                }
                else
                {
                    return Response.NotFound($"Entity with type {typeof(TEntity).GetType().Name} and Id {operatorId} is not found or already deleted");
                }
            }
            catch (Exception e)
            {
                return Response.Failed(e.Message);
            }
        }

        public async Task<IList<TEntity>> GetEntities<TEntity>(GetListRequest request) where TEntity : EntityBase
        {
            return await GetEntitiesQuerable<TEntity>()
                .AsNoTracking()
                .Skip((request.PageCount - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToArrayAsync();
        }

        protected IQueryable<TEntity> GetEntitiesQuerable<TEntity>() where TEntity : EntityBase
        {
            var dbset = context
               .Set<TEntity>();
            if (dbset != null)
            {
                return dbset.AsQueryable()
               .Where(x => !x.IsDeleted)
               .OrderBy(x => x.Id);
            }
            throw new TypeLoadException($"No dbset for {typeof(TEntity).GetType().Name} type");
        }

        protected async Task<int> GetCount<TEntity>() where TEntity : EntityBase => await GetEntitiesQuerable<TEntity>().CountAsync();



    }
}
