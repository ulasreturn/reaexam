using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;


namespace Infrastructure.Data.Postgres.Repositories.Interface;
public interface IEmployeeRepository : IRepository<Employee, int>
{
    Task<IList<Employee>> GetByIdAsync(int id);
}
