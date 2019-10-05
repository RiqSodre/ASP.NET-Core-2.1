using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tarefas.business.Models.Payloads.Base;
using tarefas.data.Model.Entities;
using tarefas.webbase.Extensions;

namespace tarefas.business.Models.Payloads
{
    public class UserPayload : BasePayloadEntity<UserEntity, UserPayload>
    {
        [Required(ErrorMessage = "É necessário enviar um nome.")]
        [MinLength(3, ErrorMessage = "É necessário que o nome tenha ao menos 3 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É necessário enviar um usuário.")]
        [MinLength(3, ErrorMessage = "É necessário que o usuário tenha ao menos 3 caracteres.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "É necessário enviar uma senha.")]
        [MinLength(6, ErrorMessage = "É necessário que a senha tenha ao menos 6 caracteres.")]
        public string Password { get; set; }

        public override UserEntity PayloadToEntity(UserPayload payload)
        {
            var entity = base.PayloadToEntity(payload);
            entity.Name = payload.Name;
            entity.Username = payload.Username;
            entity.Password = payload.Password.CalculateMd5Hash();
            return entity;
        }
    }
}
