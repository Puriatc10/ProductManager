﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Domain.SeedWork
{
    public abstract class BaseModel<TKey>
    {
        public BaseModel()
        {
            CreateDate = DateTime.Now;
        }
        public TKey Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime ModificatonDate { get; set; }
    }
}
