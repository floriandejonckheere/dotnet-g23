﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace dotnet_g23.Models.Domain
{
    public class GUser
    {
        #region Fields
        private String _email;
        #endregion

        #region Properties
        public String Email
        {
            get { return _email; }
            set
            {
                Regex regex = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email address is incorrect, please try again.");
                }
            }
        }
        public int UserId { get; private set; }
        public UserState UserState { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        #endregion

        #region Constructors
        public GUser()
        {
        }
        public GUser(String email, UserState userState)
        {
            Email = email;
            UserState = userState;
        }

        public GUser(String email) : this(email, null)
        {
        }
        #endregion

        #region Methods
        public Boolean IsParticipant()
        {
            return UserState is Participant;
        }
        public Boolean IsLector()
        {
            return UserState is Lector;
        }
        #endregion
    }
}
