using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Data.Postgres.Repositories;

  public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
  {
    public EmployeeRepository(PostgresContext postgresContext) : base(postgresContext)
    {
    }
    public async Task<IList<Employee>> GetAllAsync(Expression<Func<Employee, bool>>? filter = null)
    {
        IQueryable<Employee> commentQuery = PostgresContext.Set<Employee>();

        if (filter != null)
        {
            commentQuery = commentQuery.Where(filter);
        }

        var comments = await commentQuery
            .Include(r => r.User)
            .ToListAsync();

        return comments;
    }
    public async Task<IList<Employee>> GetByIdAsync(Expression<Func<Employee, bool>>? filter = null)
    {
        IQueryable<Employee> commentQuery = PostgresContext.Set<Employee>();

        if (filter != null)
        {
            commentQuery = commentQuery.Where(filter);
        }

        var comments = await commentQuery
            .Include(r => r.User)
            .ToListAsync();

        return comments;

    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        var employee = await PostgresContext.Set<Employee>()
            .Include(r => r.User)
            .FirstOrDefaultAsync(d => d.Id == id);

        return employee;
    }

    Task<IList<Employee>> IEmployeeRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

