using HW5.Server.DataAccess.Context;
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
    }
}
