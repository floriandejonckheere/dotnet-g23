﻿using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.LabelViewModels
{
    public class ShowViewModel
    {
        public Company Company { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
    }
}
