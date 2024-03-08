using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CostDTO:IDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }

    }
}
