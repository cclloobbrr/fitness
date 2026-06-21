using Fitness.Core.Models;
using Fitness.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitness.DataAccess.Configuration
{
    public class MembershipsConfiguration : IEntityTypeConfiguration<MembershipEntity>
    {
        public void Configure(EntityTypeBuilder<MembershipEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(Membership.MAX_NAME_LENGHT)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(Membership.MAX_DESCRIPTION_LENGHT)
                .IsRequired();

            builder.Property(m => m.Price)
                .IsRequired();
        }
    }
}
