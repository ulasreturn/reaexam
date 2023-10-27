using Core.Utilities;
using Infrastructure.Data.Postgres.Entities.Base.Interface;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgresContext _postgresContext;

    private UserRepository? _userRepository;
    private UserTokenRepository? _userTokenRepository;
    //private HastaRepository? _hastaRepository;
    private EmployeeRepository? _doktorRepository;
    //private TedaviRepository? _tedaviRepository;
    private BankAccountRepository? _randevuRepository;
    private CommentRepository? _commentRepository;
    private TransactionsRepository? _transactionsRepository;


    public UnitOfWork(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

  public IUserRepository User => _userRepository ??= new UserRepository(_postgresContext);
  public IUserTokenRepository UserTokens => _userTokenRepository ??= new UserTokenRepository(_postgresContext);
  public IEmployeeRepository Doktor => _doktorRepository ??= new EmployeeRepository(_postgresContext);
  //public IHastaRepository Hasta => _hastaRepository ??= new HastaRepository(_postgresContext);
  public IBankAccountRepository Randevu => _randevuRepository ??= new BankAccountRepository(_postgresContext);
  //public ITedaviRepository Tedavi => _tedaviRepository ??= new TedaviRepository(_postgresContext);
    public ICommentRepository Comment => _commentRepository ??= new CommentRepository(_postgresContext);
    public ITransactionsRepository Transactions => _transactionsRepository ??= new TransactionsRepository(_postgresContext);



    public async Task<int> CommitAsync()
    {
        var updatedEntities = _postgresContext.ChangeTracker.Entries<IEntity>()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity);

        foreach (var updatedEntity in updatedEntities)
        {
            updatedEntity.UpdatedAt = DateTime.UtcNow.ToTimeZone();
        }

        var result = await _postgresContext.SaveChangesAsync();

        return result;
    }

    public void Dispose()
    {
        _postgresContext.Dispose();
    }

  public Task<int> SaveChangesAsync()
  {
    throw new NotImplementedException();
  }
}
