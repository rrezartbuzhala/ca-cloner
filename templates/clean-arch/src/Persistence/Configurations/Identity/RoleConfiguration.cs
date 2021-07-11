using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace [solutionName].Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            Relationships(builder);
            builder.ToTable("Roles");
        }
        private void Relationships(EntityTypeBuilder<Role> builder)
        {

        }
    }
}
