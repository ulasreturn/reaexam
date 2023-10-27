using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class TransactionsInfoDto
    {
        public int Id { get; set; } = default!;
        public DateTime TransactionDate { get; set; }
        public int BankAccountId { get; set; }
        public string Amount { get; set; }
         public int SenderCustomerId { get; set; }
    public int ReceiverCustomerId { get; set; }
    
    public UserInfoDto SenderCustomer { get; set; }
    public UserInfoDto ReceiverCustomer { get; set; }


    }
}
