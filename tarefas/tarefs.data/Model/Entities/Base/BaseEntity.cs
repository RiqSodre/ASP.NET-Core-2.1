﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.data.Model.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Active { get; set; }
    }
}
