using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TicketDTO:IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string MuseumName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Time { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; } 
        public string CityName { get; set; }
      public string DistrictName {  get; set; }

    }
}
