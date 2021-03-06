﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_g23.Models.ViewModels.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}