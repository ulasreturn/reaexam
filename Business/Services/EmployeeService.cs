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
                // Kullan�c� bulunamad�.
                return false;
            }

            // UserType'� "Doktor" olarak g�ncelleyin
            user.UserType = UserType.Employee;

            dbContext.SaveChanges();

            return true; // Kullan�c� tipi g�ncellendi.
        }




        public bool TryCreateDoktor(int userId, string uzmanlikAlani)
        {
            // Veritaban�nda ayn� UserId'ye sahip bir doktor olup olmad���n� kontrol et
            var existingDoktor = dbContext.Employee.FirstOrDefault(d => d.UserId == userId);

            if (existingDoktor == null)
            {
                // Ayn� UserId'ye sahip bir doktor yok, yeni doktor kayd�n� ekleyin
                var newDoktor = new Employee
                {
                    UserId = userId,
                    UzmanlikAlani = uzmanlikAlani,

                    // Di�er doktor �zelliklerini doldurun
                };

                dbContext.Employee.Add(newDoktor);
                dbContext.SaveChanges();
                return true; // Ba�ar�l� bir �ekilde doktor kayd� yap�ld�.
            }

            // Ayn� UserId'ye sahip bir doktor zaten var, i�lem ba�ar�s�z oldu.
            return false;
        }
    }

}
