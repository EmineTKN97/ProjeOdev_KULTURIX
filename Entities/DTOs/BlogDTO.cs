using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
public class BlogDTO:IDto
    {
        public Guid İd { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string İmagePath { get; set; }
        public DateTime BlogDate { get; set; }
        public Guid UserId { get; set; }

    }
}
