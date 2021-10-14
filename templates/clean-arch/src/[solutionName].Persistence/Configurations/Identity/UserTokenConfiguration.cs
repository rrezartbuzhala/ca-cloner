using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace [solutionName].Persistence.Configurations.Identity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            Relationships(builder);

            builder.ToTable("UserTokens");
        }

        private void Relationships(EntityTypeBuilder<UserToken> builder)
        {
           
        }
    }
}
