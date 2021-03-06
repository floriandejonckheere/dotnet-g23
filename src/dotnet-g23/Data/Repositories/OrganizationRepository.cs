﻿using System.Collections.Generic;
using System.Linq;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Organization> _organizations;

        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
            _organizations = context.Organizations;
        }

        public IEnumerable<Organization> GetAll()
        {
            return _organizations
                .ToList();
        }

        public Organization GetBy(int organizationId)
        {
            return _organizations
                .SingleOrDefault(o => o.OrganizationId == organizationId);
        }

        public IEnumerable<Organization> GetByKeyword(string query)
        {
            return _organizations
                .Where(org => org.Name.Contains(query) || org.Location.Contains(query))
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}