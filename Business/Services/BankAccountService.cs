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
            // Veritabanýnda ayný UserId'ye sahip bir doktor olup olmadýðýný kontrol et
            var existingBankAccount = dbContext.BankAccount.FirstOrDefault(d => d.CustomerId == customerId);

            if (existingBankAccount == null)
            {
                // Ayný UserId'ye sahip bir doktor yok, yeni doktor kaydýný ekleyin
                var bankAccount = new BankAccount
                {
                    CustomerId = customerId,
                    AccountNumber=accountNumber
                 


                    // Diðer doktor özelliklerini doldurun
                };

                dbContext.BankAccount.Add(bankAccount);
                dbContext.SaveChanges();
                return true; // Baþarýlý bir þekilde doktor kaydý yapýldý.
            }

            // Ayný UserId'ye sahip bir doktor zaten var, iþlem baþarýsýz oldu.
            return false;
        }

    }
    }

