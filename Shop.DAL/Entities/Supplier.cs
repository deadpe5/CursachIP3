using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int PostalCode { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Ware> Wares { get; set; }

    }
}
