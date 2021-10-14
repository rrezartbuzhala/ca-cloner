using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace [solutionName].Persistence.Configurations.Identity
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            Relationships(builder);

            builder.ToTable("UserLogins");
        }

        private void Relationships(EntityTypeBuilder<UserLogin> builder)
        {
           
        }
    }
}
