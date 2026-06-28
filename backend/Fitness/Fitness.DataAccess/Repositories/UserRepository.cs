using Fitness.Core.Abstractions;
using Fitness.Core.Models;
using Fitness.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace Fitness.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly FitnessDbContext _context;

        public UserRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetById(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
