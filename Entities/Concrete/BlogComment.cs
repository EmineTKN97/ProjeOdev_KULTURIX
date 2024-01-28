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
        public Guid CommentId { get; set; }
        public  Guid UserId{ get; set; }
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
        public Blog Blog { get; set; }
        public User User { get; set; }
        public virtual ICollection<BlogLike> BlogLikes { get; set; }
    }
}
