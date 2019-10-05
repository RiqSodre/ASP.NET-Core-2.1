using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.data.Model.Entities;

namespace tarefas.repositories.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByUsarname(string username);
        Task<bool> HasUsername(string username);
    }
}
