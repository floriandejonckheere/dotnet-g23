﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Lector : UserRole
    {
        #region Properties
        public ICollection<Group> Groups { get; set; }
        public ICollection<Participant> Participants { get; set; }
        #endregion
    }
}
