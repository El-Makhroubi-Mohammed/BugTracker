using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Interfaces
{
    public interface IBugRepository
    {
        Task<Bug?> GetByIdAsync(int id);
        Task<List<Bug>> GetAllAsync();
        Task AddAsync(Bug bug);
        Task UpdateAsync(Bug bug);
        Task DeleteAsync(Bug bug);
    }
}
