using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

    builder.HasKey(u => u.Id); 
    builder.Property(u => u.TCKimlikNo).IsRequired().HasMaxLength(11);
    builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
    builder.Property(u => u.UserSurname).IsRequired().HasMaxLength(50);
    builder.Property(u => u.PasswordHash).IsRequired();
    builder.Property(u => u.PasswordSalt).IsRequired();
    builder.Property(u => u.Country).IsRequired().HasMaxLength(50);
    builder.Property(u => u.City).IsRequired().HasMaxLength(50);
    builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
    builder.Property(u => u.Telephone).HasMaxLength(20);
    builder.Property(u => u.UserType).IsRequired();
    builder.Property(x => x.UserPhoto).IsRequired();


     builder.HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);
     

        builder.HasMany(c => c.BankAccount)
            .WithOne(b => b.Customer)
            .HasForeignKey(b => b.CustomerId);

        builder.HasMany(c => c.SentTransactions)
           .WithOne(t => t.SenderCustomer)
           .HasForeignKey(t => t.SenderCustomerId);

        builder.HasMany(c => c.ReceivedTransactions)
            .WithOne(t => t.ReceiverCustomer)
            .HasForeignKey(t => t.ReceiverCustomerId);










    }
}
