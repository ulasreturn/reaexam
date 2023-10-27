 using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities
{
  public class Transactions : Entity<int>
  {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int BankAccountId { get; set; } 
        public string Amount { get; set; }
        public string Aciklama { get; set; }
        public BankAccount BankAccount { get; set; }

        public int SenderCustomerId { get; set; }
        public int ReceiverCustomerId { get; set; }

        public User SenderCustomer { get; set; }
        public User  ReceiverCustomer { get; set; }

    }
}
