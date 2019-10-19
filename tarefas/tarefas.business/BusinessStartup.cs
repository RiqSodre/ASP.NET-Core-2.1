using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.business.Business;
using tarefas.repositories;

namespace tarefas.business
{
    public static class BusinessStartup
    {
        public static void AddServices(IServiceCollection service)
        {
            service.AddScoped<UserBusiness>();

            RepositoryStartup.AddServices(service);
        }
    }
}
