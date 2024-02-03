using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogLikeDTO:IDto
    {
       
        public DateTime LikeDate { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }

    }
}
