using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogCommentDTO : IDto
    {
        public Guid CommentId { get; set; }
        public string CommentTitle { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string? Email { get; set; }
        public string CommentDetail { get; set; }
        public int? BlogLikeCount { get; set; }
         public DateTime CommentDate { get; set; }
        public string? UserİmagePath { get; set; }
        public string? BlogTitle { get; set; }
        public Guid BlogId { get; set; }
    }
}
