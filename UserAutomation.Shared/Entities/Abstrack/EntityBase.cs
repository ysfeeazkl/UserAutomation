﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOtomation.Shared.Entities.Abstrack
{
    public abstract class EntityBase<T> where T : struct
    {
        public virtual T ID { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual T CreatedByUserId { get; set; }
        public virtual T ModifiedByUserId { get; set; }
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
