using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class WareStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<Ware> Wares { get; set; }
    }
}
