using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities
{
    public class BankAccount : Entity<int>
    {

        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public List<Transactions> Transactions { get; set; }
    }
}
