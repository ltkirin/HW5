using HW5.Server.Business.Interfaces;
using HW5.Server.Business.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Business
{
    public static class Bootstrap
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientsService>();
            services.AddTransient<IOperatorsService, OperatorsService>();
            services.AddTransient<IQuestionnairesService, QuestionnairesService>();
        }
    }
}
