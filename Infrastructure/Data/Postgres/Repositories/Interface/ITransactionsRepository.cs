using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;

namespace Infrastructure.Data.Postgres.Repositories.Interface;
public interface ITransactionsRepository : IRepository<Transactions, int>
{
    Task<IList<Transactions>> GetByTransactionsIdAsync(int id);
}
