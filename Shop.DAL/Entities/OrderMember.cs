using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class OrderMember
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
