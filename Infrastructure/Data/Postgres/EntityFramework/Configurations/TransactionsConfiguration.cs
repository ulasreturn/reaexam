
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Data.Postgres.Entities;
namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class TransactionsConfiguration : IEntityTypeConfiguration<Transactions>
{
  public void Configure(EntityTypeBuilder<Transactions> builder)
  {
    builder.ToTable("Transactions");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TransactionDate).IsRequired();
        builder.Property(t => t.Amount).IsRequired();
        builder.Property(t => t.Aciklama).IsRequired();


        builder.HasOne(t => t.BankAccount)
                .WithMany(h => h.Transactions)
                .HasForeignKey(t => t.BankAccountId);

        builder.HasOne(t => t.SenderCustomer)
           .WithMany(c => c.SentTransactions)
           .HasForeignKey(t => t.SenderCustomerId);

        builder.HasOne(t => t.ReceiverCustomer)
            .WithMany(c => c.ReceivedTransactions)
            .HasForeignKey(t => t.ReceiverCustomerId);
    }
} 
