using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogLikeDTO:IDto
    {
        public Guid Likeİd { get; set; }
        public Guid? Blogid { get; set; }
        public Guid? BlogCommentid { get; set; }
        public Guid Userid { get; set; }
        public DateTime LikeDate { get; set; }

    }
}
