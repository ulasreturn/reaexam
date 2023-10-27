using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Infrastructure.Data.Postgres.Repositories;

public class BankAccountRepository : Repository<BankAccount, int>, IBankAccountRepository
{
    private PostgresContext _context;
    public BankAccountRepository(PostgresContext postgresContext) : base(postgresContext)
  {
        _context = postgresContext;

  }
    public async Task<IList<BankAccount>> GetAllAsync(Expression<Func<BankAccount, bool>>? filter = null)
    {
        IQueryable<BankAccount> commentQuery = PostgresContext.Set<BankAccount>();

        if (filter != null)
        {
            commentQuery = commentQuery.Where(filter);
        }

        var comments = await commentQuery
            .Include(r => r.Customer)
            .Include(r => r.Transactions)
            .ToListAsync();

        return comments;
    }

    public Task<IList<BankAccount>> GetByBankAccountIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}

