using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAdress { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<BlogLike> BlogLikes { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
