﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public class Group
    {
        #region Fields
        private String _name;
        private Boolean _isClosed = true;
        #endregion

        #region Properties
        public int GroupId { get; set; }
        public String Name
        {
            get { return _name; }
            private set {
                if(value.Equals(null) || value.Trim() == String.Empty || value == String.Empty)
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                _name = value;
            }
        }
        #endregion

        #region Constructors
        public Group(String name)
        {
            Name = name;
        }

        public Group(String name, Boolean isClosed) : this(name)
        {
            _isClosed = isClosed;
        }
        #endregion
    }
}
