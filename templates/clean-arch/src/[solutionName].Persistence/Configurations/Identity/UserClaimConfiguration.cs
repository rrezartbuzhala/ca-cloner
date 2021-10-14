using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace [solutionName].Persistence.Configurations.Identity
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            Relationships(builder);
            builder.ToTable("UserClaims");
        }
        private void Relationships(EntityTypeBuilder<UserClaim> builder)
        {

        }
    }
}
