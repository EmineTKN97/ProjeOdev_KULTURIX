﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public  class BlogDetailsDTO:IDto
    {
        public Guid  İd{ get; set; }

        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

        public  string BlogTitle { get; set; }

        public DateTime BlogDate { get; set; }
        public DateTime BlogCommentDate { get; set; }

        public  string  BlogContent { get; set; }

        public string  BlogCommentTitle { get; set; }

        public  string  BlogCommentText { get; set; }

        public Guid id { get; set; }
        public bool Status { get; set; }
    }

   
}
