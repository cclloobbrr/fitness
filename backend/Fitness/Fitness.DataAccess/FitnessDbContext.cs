using Fitness.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace Fitness.DataAccess
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options) 
        {
        }

        public DbSet<MembershipEntity> Memberships { get; set; }
    }
}
