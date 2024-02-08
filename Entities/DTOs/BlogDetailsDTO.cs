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
        public string Title { get; set; }
        public DateTime BlogDate { get; set; }
        public string Content { get; set; }
        public int BlogLikeCount { get; set; }
        public int BlogCommentCount { get; set; }
        public string İmagePath { get; set; }
        public string Name{ get; set; }
        public string SurName { get; set; }

    }


}
