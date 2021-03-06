﻿using System.Collections.Generic;

namespace dotnet_g23.Models.Domain
{
    public class Participant : UserState
    {
        #region Properties

        public Organization Organization { get; set; }
        public Group Group { get; set; }
        public Lector Lector { get; private set; }
        public ICollection<Invitation> Invitations { get; }

        #endregion

        #region Constructors

        public Participant()
        {
            Invitations = new List<Invitation>();
        }

        public Participant(Organization organization) : this()
        {
            Organization = organization;
        }

        #endregion
    }
}