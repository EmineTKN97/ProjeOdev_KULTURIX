
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cost:IEntity
    {
        public Guid Id{ get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Price { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
