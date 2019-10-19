using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.data.Contexts;

namespace tarefas.data
{
    public static class DataStartup
    {
        public static void AddConnectionStringContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
        }
        
    }
}
