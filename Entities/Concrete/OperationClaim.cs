using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class OperationClaim:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<AdminOperationClaim> AdminOperationClaims { get; set; }
    }
}
