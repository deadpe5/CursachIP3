using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class WareType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Ware> Wares { get; set; }
    }
}
