﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTemplate.Data.Common.Models
{
    public interface IEntityWithCreator
    {
        string UserId { get; set; }
    }
}
