using HW5.Server.DataAccess.Context;
using HW5.Server.Domain.Models;
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
