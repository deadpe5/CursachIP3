using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Ware
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Manufactured { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public int WareStatusId { get; set; }
        [ForeignKey("WareStatusId")]
        public virtual WareStatus WareStatus { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual WareType WareType { get; set; }
        public virtual ICollection<OrderWare> OrderWares { get; set; }
        public virtual ICollection<RAM> RAM { get; set; }
        public virtual ICollection<CPU> CPUs { get; set; }
        public virtual ICollection<GPU> GPUs { get; set; }
    }
}
