using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserForRegisterDto
    {
        public string UserName { get; set; }    
        public string Password { get; set; }    

        public Boolean IsAdmin { get; set; }
    }
}
