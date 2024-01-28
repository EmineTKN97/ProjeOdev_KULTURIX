using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public  class BlogLike:IEntity
    {
        public Guid LikeId { get; set; }
        public Guid? BlogId { get; set; }
        public Guid? BlogCommentId { get; set; }
        public  Guid UserId { get; set; }
        public DateTime LikeDate { get; set; }
        public bool Status { get; set; }
        public Blog blog { get; set; }
        public User User { get; set; }
        public BlogComment comment { get; set; }
    }
}
