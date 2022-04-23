using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class RAM
    {
        public int Id { get; set; }
        public int Speed { get; set; }
        public int Size { get; set; }
        public int WareId { get; set; }
        public virtual Ware Ware { get; set; }
    }
}
