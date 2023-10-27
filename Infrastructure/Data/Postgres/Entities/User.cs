using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities;

public class User : Entity<int>
{
 
  public string TCKimlikNo { get; set; } = default!;
  public string UserName { get; set; } = default!;
  public string UserSurname { get; set; } = default!;
  public byte[] PasswordSalt { get; set; } = default!;
  public byte[] PasswordHash { get; set; } = default!;
  public string Country { get; set; } = default!;
  public string City { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string Telephone { get; set; } = default!;
   public string UserPhoto { get; set; } = default!;
    public UserType UserType { get; set; }

    public ICollection<Employee> Employee { get; set; }
    public IList<Comment> Comments { get; set; }
    public ICollection<BankAccount> BankAccount { get; set; }
    public List<Transactions> SentTransactions { get; set; }
    public List<Transactions> ReceivedTransactions { get; set; }



}

public enum UserType
{
    Customer,
    Admin,
    Employee,
 
}
