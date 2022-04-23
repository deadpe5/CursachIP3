using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class OrderWare
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int WareId { get; set; }
        public virtual Ware Ware { get; set; }
    }
}
