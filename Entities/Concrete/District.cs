using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public int SehirId { get; set; }
        public string DistrictName { get; set; }
        public City City { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
