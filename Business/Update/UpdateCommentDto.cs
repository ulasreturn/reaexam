using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Update
{
    public class UpdateCommentDto
    {
        public DateTime CommentDate { get; set; } = default!;
        public int UserId { get; set; } = default!;
        public int EmployeeId { get; set; } = default!;
        public string CommentText { get; set; } = default!;
    }
}
