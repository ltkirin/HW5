﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Domain.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
