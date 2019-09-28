using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tarefas.data.Model.Entities.Base;

namespace tarefas.data.Model.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }

        public virtual ICollection<TaskEntity> Tasks { get; set; }

    }
}
