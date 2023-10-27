using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Data.Postgres.Entities;
using System.Reflection.Emit;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
  public void Configure(EntityTypeBuilder<BankAccount> builder)
  {
    builder.ToTable("BankAccount");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.AccountNumber).IsRequired().HasMaxLength(20);
      
        // Diðer hesap özellikleri için konfigürasyonlar burada eklenebilir.

        builder.HasOne(b => b.Customer)
            .WithMany(c => c.BankAccount)
            .HasForeignKey(b => b.CustomerId);
        builder.HasIndex(d => d.CustomerId).IsUnique();

        builder.HasMany(b => b.Transactions)
            .WithOne(t => t.BankAccount)
            .HasForeignKey(t => t.Id);



    }
}
  
