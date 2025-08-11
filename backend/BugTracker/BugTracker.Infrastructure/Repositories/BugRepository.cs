using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using BugTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly AppDbContext _context;

        public BugRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bug?> GetByIdAsync(int id)
        {
            return await _context.Bugs
                .Include(b => b.Project)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Bug>> GetAllAsync()
        {
            return await _context.Bugs
                .Include(b => b.Project)
                .ToListAsync();
        }

        public async Task AddAsync(Bug bug)
        {
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bug bug)
        {
            _context.Bugs.Update(bug);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bug bug)
        {
            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();
        }
    }
}
