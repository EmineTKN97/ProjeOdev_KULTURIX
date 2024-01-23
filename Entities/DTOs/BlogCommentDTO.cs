using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogCommentDTO : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDetail { get; set; }
        public DateTime CommentDate { get; set;}
        public bool Status { get; set; }
    }
}
