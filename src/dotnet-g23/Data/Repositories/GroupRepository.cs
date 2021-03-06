﻿using System.Collections.Generic;
using System.Linq;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Group> _groups;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
            _groups = context.Groups;
        }

        public IEnumerable<Group> GetAll()
        {
            return _groups
                .Include(g => g.Organization)
                .Include(g => g.Motivation)
                .Include(g => g.Lector)
                .Include(g => g.Participants)
                .Include(g => g.Label)
                .Include(g => g.Actions)
                .OrderBy(g => g.Name)
                .ToList();
        }

        public Group GetBy(int groupId)
        {
            return _groups
                .Include(g => g.Organization)
                .Include(g => g.Motivation)
                .Include(g => g.Lector)
                .Include(g => g.Participants)
                .Include(g => g.Label)
                .Include(g => g.Actions)
                .SingleOrDefault(g => g.GroupId == groupId);
        }

        public IEnumerable<Group> GetByOrganization(Organization organization)
        {
            return _groups
                .Include(g => g.Organization)
                .Include(g => g.Motivation)
                .Include(g => g.Lector)
                .Include(g => g.Participants)
                .Include(g => g.Label)
                .Include(g => g.Actions)
                .OrderBy(g => g.Name)
                .Where(g => (g.Organization != null) && (g.Organization == organization));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}