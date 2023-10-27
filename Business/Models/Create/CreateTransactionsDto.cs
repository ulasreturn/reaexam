using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Create
{
    public class CreateTransactionsDto
    {
        public DateTime TransactionDate { get; set; }
        public int BankAccountId { get; set; }
        public string Amount { get; set; }
        public string Aciklama { get; set; }
        public int SenderCustomerId { get; set; }
        public int ReceiverCustomerId { get; set; }


        // Diðer ilgili sütunlar...
        // Diðer ilgili sütunlar...

    }
}
