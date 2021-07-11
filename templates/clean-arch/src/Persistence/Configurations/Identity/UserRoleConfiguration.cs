using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace [solutionName].Persistence.Configurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            Relationships(builder);

            builder.ToTable("UserRoles");
        }

        private void Relationships(EntityTypeBuilder<UserRole> builder)
        {
           
        }
    }
}
