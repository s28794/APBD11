using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class GroupEfConfig : IEntityTypeConfiguration<Group> 
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder
            .HasKey(x => x.Id)
            .HasName("Group_pk");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(5);

        builder.ToTable(nameof(Group));

        Group[] groups =
        {
            new Group { Id = 1, Name = "10c" },
            new Group { Id = 2, Name = "30c" }
        };

        builder.HasData(groups);
    }
}