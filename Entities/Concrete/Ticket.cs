using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ticket : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string MuseumName { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public DateTime Time { get; set; }
        public User user { get; set; }
        public City city { get; set; }
        public District District {  get; set; }
      
   

    }
}
