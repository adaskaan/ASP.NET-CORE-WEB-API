using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Entry:IEntity
    {
        public int Id { get; set; }
        public int categoryId { get; set; }
        public int userId { get; set; }
        public string header { get; set; }
        public string body { get; set; }
        public string tags { get; set; }
        public string subject { get; set; }
       public Boolean isApproved { get; set; }
 
    }
}
