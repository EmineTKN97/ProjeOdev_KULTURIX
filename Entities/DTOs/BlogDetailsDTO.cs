using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogDetailsDTO : IDto
    {
        public Guid İd { get; set; }
        public string BlogTitle { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }
        public int BlogLikeCount { get; set; }
        public int BlogCommentCount { get; set; }
        public string İmagePath { get; set; }
    }


}
