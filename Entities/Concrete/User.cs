using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class User: IEntity
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public long? Identity { get; set; }
        public bool Status { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
        public virtual ICollection<BlogLike> BlogLikes { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
