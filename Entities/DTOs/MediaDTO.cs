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
        public string Name { get; set; }
        public string SurName { get; set; }
        public  string BlogTitle { get; set; }
        public  string  BlogDescription { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
