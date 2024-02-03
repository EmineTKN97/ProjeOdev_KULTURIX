using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MediaDTO:IDto
    {
        public Guid MediaId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? BlogId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
