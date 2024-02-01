using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class AnnouncementDTO:IDto
    {
        public Guid Id { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementContent { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
