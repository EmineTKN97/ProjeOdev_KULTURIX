using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimsId { get; set; }
        public User User { get; set; }
        public  OperationClaim OperationClaim { get; set; }
    }
}
