﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class GBOrganization : OrganizationRole
    {
        #region Properties
        public ICollection<Group> Groups { get; set; }
        #endregion
    }
}
