using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BlogComment:IEntity
    {
        public  Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public  string CommentText { get; set; }
     
        public Blog blog{ get; set; }
    }
}
