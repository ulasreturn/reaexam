using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;

namespace Infrastructure.Data.Postgres.Repositories.Interface;
public interface IBankAccountRepository : IRepository<BankAccount, int>
{
    Task<IList<BankAccount>> GetByBankAccountIdAsync(int id);
}
