using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefas.business.Models.Payloads;
using tarefas.business.Models.Proxies;
using tarefas.repositories.Repositories.Interfaces;
using tarefas.webbase.Extensions;

namespace tarefas.business.Business
{
    public class UserBusiness
    {
        private readonly IUserRepository _userRepository;


        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserProxy> Login(LoginPayload payload)
        {
            var user = await _userRepository.GetByUsarname(payload.Username);

            if (user == null)
                throw new InvalidProgramException("Usuário não encontrado.");

            if (user.Password != payload.Password.CalculateMd5Hash())
                throw new InvalidProgramException("Senha inválida.");

            return new UserProxy().EntityToProxy(user);
        }

        public async Task Create(UserPayload payload)
        {
            if (await _userRepository.HasUsername(payload.Username))
                throw new InvalidProgramException("Esse usuário já existe.");

            var entity = payload.PayloadToEntity(payload);

            await _userRepository.Create(entity);
        }
    }
}
