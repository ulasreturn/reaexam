using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Data.Postgres.Repositories;

public class TransactionsRepository : Repository<Transactions, int>, ITransactionsRepository
{
    private PostgresContext _context;
    public TransactionsRepository(PostgresContext postgresContext) : base(postgresContext)
    {
        _context = postgresContext;
    }
    public async Task<IList<Transactions>> GetAllAsync(Expression<Func<Transactions, bool>>? filter = null)
    {
        IQueryable<Transactions> commentQuery = PostgresContext.Set<Transactions>();

        if (filter != null)
        {
            commentQuery = commentQuery.Where(filter);
        }

        var comments = await commentQuery
            .Include(r => r.SenderCustomer)
            .Include(r => r.ReceiverCustomer)
            .ToListAsync();

        return comments;
    }
    public async Task<IList<Transactions>> GetByIdAsync(Expression<Func<Transactions, bool>>? filter = null)
    {
        IQueryable<Transactions> commentQuery = PostgresContext.Set<Transactions>();

        if (filter != null)
        {
            commentQuery = commentQuery.Where(filter);
        }

        var comments = await commentQuery
            .Include(r => r.ReceiverCustomerId)
            .ToListAsync();

        return comments;

    }
    public Task<IList<Transactions>> GetByTransactionsIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

