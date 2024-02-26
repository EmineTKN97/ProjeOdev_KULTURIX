using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
            public Guid BlogId { get; set; }
            public Guid UserId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime Date { get; set; }
             public string ImagePath { get; set; }
            public bool Status { get; set; }
            public virtual ICollection<BlogComment> BlogComments { get; set; }
            public virtual ICollection<BlogLike> BlogLikes { get; set; }
            public virtual ICollection<Media> Medias { get; set; }
            public User User { get; set; }
    }
    }


