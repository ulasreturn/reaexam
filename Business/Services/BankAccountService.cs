using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BankAccountService : BaseService<BankAccount, int, BankAccountInfoDto>, IBankAccountService
    {
        private readonly PostgresContext dbContext;
        public BankAccountService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper, PostgresContext dbContext) : base(unitOfWork, unitOfWork.Randevu, mapperHelper)
        {
            this.dbContext = dbContext;
        }

        public bool TryCreateBankAccount(int customerId, string accountNumber)
        {
            // Veritaban�nda ayn� UserId'ye sahip bir doktor olup olmad���n� kontrol et
            var existingBankAccount = dbContext.BankAccount.FirstOrDefault(d => d.CustomerId == customerId);

            if (existingBankAccount == null)
            {
                // Ayn� UserId'ye sahip bir doktor yok, yeni doktor kayd�n� ekleyin
                var bankAccount = new BankAccount
                {
                    CustomerId = customerId,
                    AccountNumber=accountNumber
                 


                    // Di�er doktor �zelliklerini doldurun
                };

                dbContext.BankAccount.Add(bankAccount);
                dbContext.SaveChanges();
                return true; // Ba�ar�l� bir �ekilde doktor kayd� yap�ld�.
            }

            // Ayn� UserId'ye sahip bir doktor zaten var, i�lem ba�ar�s�z oldu.
            return false;
        }

    }
    }

