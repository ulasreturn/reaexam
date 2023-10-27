using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class CommentInfoDto
    {
        public int Id { get; set; } = default!;
        public DateTime CommentDate { get; set; } = default!;
        public int UserId { get; set; } = default!;
        public string CommentText { get; set; } = default!;

        public int EmployeeId { get; set; } = default!;


    }
}
