﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Participant : UserRole
    {
        #region Properties
        public Group Group { get; set; }
        #endregion
    }
}
