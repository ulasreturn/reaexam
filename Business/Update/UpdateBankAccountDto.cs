using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Update
{
    public class UpdateBankAccountDto
    {
     
        public string AccountNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
