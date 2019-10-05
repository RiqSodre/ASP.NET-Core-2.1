using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.repositories.Repositories.Interfaces;
using tarefas.repositories.Repositories.Sql;

namespace tarefas.repositories
{
    public static class RepositoryStartup
    {
        public static void AddServices(IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
