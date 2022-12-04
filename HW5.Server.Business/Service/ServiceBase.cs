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

        public async Task<Response<IList<TEntity>>> GetEntities<TEntity>(GetListRequest request) where TEntity : EntityBase
        {
            try
            {
                var querable = GetEntitiesQuerable<TEntity>();
                var count = await querable.CountAsync();
                var entites = await querable
                    .AsNoTracking()
                    .Skip(request.PageCount * request.PageSize)
                    .Take(request.PageSize)
                    .ToArrayAsync();

                var result = Response<IList<TEntity>>.Ok(entites);
                result.Metadata.Add("Total", $"{count}");
                return result;
            }
            catch (Exception e)
            {
                return Response<IList<TEntity>>.Failed(e.Message);
            }
        }

        protected IQueryable<TEntity> GetEntitiesQuerable<TEntity>() where TEntity : EntityBase
        {
            var dbset = context
               .Set<TEntity>();
            if(dbset != null)
            {
                return dbset.AsQueryable()
               .Where(x => !x.IsDeleted);
            }
            throw new TypeLoadException($"No dbset for {typeof(TEntity).GetType().Name} type");
        }
    }
}
