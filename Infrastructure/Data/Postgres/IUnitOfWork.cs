using Infrastructure.Data.Postgres.Repositories.Interface;

namespace Infrastructure.Data.Postgres;

public interface IUnitOfWork : IDisposable
{
  IUserRepository User { get; }
  IUserTokenRepository UserTokens { get; }

  //IHastaRepository Hasta { get; }
  IEmployeeRepository Doktor { get; }
  IBankAccountRepository Randevu { get; }
  //ITedaviRepository Tedavi { get; }
    ICommentRepository Comment { get; }
    ITransactionsRepository Transactions { get; }


    Task<int> CommitAsync();
  Task<int> SaveChangesAsync();
}
