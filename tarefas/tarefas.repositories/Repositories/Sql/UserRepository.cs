using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tarefas.data.Contexts;
using tarefas.data.Model.Entities;
using tarefas.repositories.Repositories.Interfaces;
using tarefas.repositories.Repositories.Sql.Base;

namespace tarefas.repositories.Repositories.Sql
{
    public class UserRepository : BaseRepository<SqlContext, UserEntity>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context, context.Users)
        {

        }
        
        public async Task<UserEntity> GetByUsarname(string username)
        {
            var user = await dbSet.FirstOrDefaultAsync(f => f.Active && f.Username == username);

            return user;
        }

        public async Task<bool> HasUsername(string username) =>  await dbSet.AnyAsync(a => a.Username == username);

    }
}
