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
        public static void AddDataAccess(this IServiceCollection services)
        {
            var builder = new NpgsqlConnectionStringBuilder("Host=localhost;Port=5432;Database=wh5db;Username=postgres;Password=ne4hbsgx");
            services.AddDbContext<PgSqlApplicationContext>(options =>
                options.UseNpgsql(builder.ConnectionString));

        }
    }
}
