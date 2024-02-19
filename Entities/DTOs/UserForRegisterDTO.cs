using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public class UserForRegisterDTO:IDto
    {
     
        public string Email { get; set; }
        public string Password { get; set; }
        public  string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
