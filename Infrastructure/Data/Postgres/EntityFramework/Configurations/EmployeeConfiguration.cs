using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.ToTable("Employee");
        builder.Property(d => d.UzmanlikAlani).HasMaxLength(100);
        builder.Property(r => r.Cinsiyet).IsRequired();
        builder.Property(r => r.DogumTarihi).IsRequired();



        builder.HasOne(u => u.User)
           .WithMany(c => c.Employee)
           .HasForeignKey(c => c.UserId);
         builder.HasIndex(d => d.UserId).IsUnique();


        builder.HasMany(u => u.Comments)
               .WithOne(c => c.Employee)
               .HasForeignKey(c => c.EmployeeId);


    }
}

