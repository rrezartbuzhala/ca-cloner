using [solutionName].Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace [solutionName].Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("Firstname")
                .IsRequired();

            builder.Property(x => x.LastName)
               .HasColumnName("Lastname")
               .IsRequired();

            Relationships(builder);

            builder.ToTable("Users");
        }

        private void Relationships(EntityTypeBuilder<User> builder)
        {
           
        }
    }
}
