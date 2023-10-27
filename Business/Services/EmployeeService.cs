using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService : BaseService<Employee, int, EmployeeInfoDto>, IEmployeeService
    {
        private readonly PostgresContext dbContext;
        public EmployeeService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper, PostgresContext dbContext) : base(unitOfWork, unitOfWork.Doktor, mapperHelper)
        {
            this.dbContext = dbContext;
        }
      public bool UpdateUserTypeToEmployee(int userId)
        {
            var user = dbContext.User.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                // Kullanýcý bulunamadý.
                return false;
            }

            // UserType'ý "Doktor" olarak güncelleyin
            user.UserType = UserType.Employee;

            dbContext.SaveChanges();

            return true; // Kullanýcý tipi güncellendi.
        }




        public bool TryCreateDoktor(int userId, string uzmanlikAlani)
        {
            // Veritabanýnda ayný UserId'ye sahip bir doktor olup olmadýðýný kontrol et
            var existingDoktor = dbContext.Employee.FirstOrDefault(d => d.UserId == userId);

            if (existingDoktor == null)
            {
                // Ayný UserId'ye sahip bir doktor yok, yeni doktor kaydýný ekleyin
                var newDoktor = new Employee
                {
                    UserId = userId,
                    UzmanlikAlani = uzmanlikAlani,

                    // Diðer doktor özelliklerini doldurun
                };

                dbContext.Employee.Add(newDoktor);
                dbContext.SaveChanges();
                return true; // Baþarýlý bir þekilde doktor kaydý yapýldý.
            }

            // Ayný UserId'ye sahip bir doktor zaten var, iþlem baþarýsýz oldu.
            return false;
        }
    }

}
