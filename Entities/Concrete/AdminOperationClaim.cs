using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AdminOperationClaim:IEntity
    {
        public Guid Id { get; set; }
        public Guid AdminId { get; set; }
        public Guid OperationClaimsId { get; set; }
        public Admin Admin { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
