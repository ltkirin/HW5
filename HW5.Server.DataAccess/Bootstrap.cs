using HW5.Server.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.DataAccess
{
    public static class Bootstrap
    {
        public static void AddDataAccess(this IServiceCollection services, NpgsqlConnectionStringBuilder dbOptionsBuilder)
        {
            services.AddDbContext<PgSqlApplicationContext>(options =>
                options.UseNpgsql(dbOptionsBuilder.ConnectionString));

        }
    }
}
