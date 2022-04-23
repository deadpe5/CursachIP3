using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Ware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Manufactured { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int WareStatudId { get; set; }
        public virtual WareStatus WareStatusId { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<OrderWare> OrderWares { get; set; }
        public virtual ICollection<RAM> RAM { get; set; }
        public virtual ICollection<CPU> CPUs { get; set; }
        public virtual ICollection<GPU> GPUs { get; set; }
    }
}
