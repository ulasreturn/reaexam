using Infrastructure.Data.Postgres.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Comment : Entity<int>
    {
        public int UserId { get; set; } = default!; //User tablosundan user id ile ilişkilendirilecek
        public int EmployeeId { get; set; } = default!;
        public string CommentText { get; set; } = default!;
        public DateTime CommentDate { get; set; } = default!;


        //REFERANSLAR
        public User User { get; set; }
        public Employee Employee { get; set; }

    }
}

