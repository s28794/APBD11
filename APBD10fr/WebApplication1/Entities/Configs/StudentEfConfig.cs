using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class StudentEfConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .HasKey(x => x.Id)
            .HasName("Group_pk");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(10);
        
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(30);
        
        builder
            .Property(x => x.IndexNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.ToTable(nameof(Student));

        Student[] students =
        {
            new Student { Id = 1, FirstName = "AA", LastName = "DD", IndexNumber = "12354"},
            new Student { Id = 2, FirstName = "BB", LastName = "FFF", IndexNumber = "124565"}
        };

        builder.HasData(students);
    }
}