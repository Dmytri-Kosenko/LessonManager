﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}