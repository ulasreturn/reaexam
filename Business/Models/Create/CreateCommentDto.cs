using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Create
{
    public class CreateCommentDto
    {
        public string CommentText { get; set; } = default!;
        public DateTime CommentDate { get; set; } = default!;
        public int UserId { get; set; } = default!;
        public int EmployeeId { get; set; } = default!;



    }
}
