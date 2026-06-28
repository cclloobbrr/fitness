using Fitness.Core.Abstractions;
using Fitness.Core.Models;
using Fitness.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace Fitness.DataAccess.Repositories
{
    public class MembershipsRepository : IMembershipsRepository
    {
        private readonly FitnessDbContext _context;

        public MembershipsRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<List<Membership>> GetMemberships()
        {
            var membershipsEntities = await _context.Memberships
                .AsNoTracking()
                .ToListAsync();

            var memberships = membershipsEntities
                .Select(m => Membership.Create(m.Id, m.Name, m.Description, m.Price).Membership)
                .ToList();

            return memberships;
        }

        public async Task<Guid> Create(Membership membership)
        {
            var membershipsEntities = new MembershipEntity
            {
                Id = membership.Id,
                Name = membership.Name,
                Description = membership.Description,
                Price = membership.Price,
            };

            await _context.Memberships.AddAsync(membershipsEntities);
            await _context.SaveChangesAsync();

            return membershipsEntities.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description, decimal price)
        {
            await _context.Memberships
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(m => m.Name, m => name)
                    .SetProperty(m => m.Description, m => description)
                    .SetProperty(m => m.Price, m => price));

            return id;
        }

        public async Task<Guid?> Delete(Guid id)
        {
            var deletedCount = await _context.Memberships
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return deletedCount > 0 ? id : null;
        }
    }
}
