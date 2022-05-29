using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Goods
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Manufactured { get; set; }
        [Required]
        public double Diagonal { get; set; }
        [Required]
        public int CoreCount { get; set; }
        [Required]
        public int RAMSize { get; set; }
        [Required]
        public int ROMSize { get; set; } 
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public int GoodsStatusId { get; set; }
        [ForeignKey("GoodsStatusId")]
        public virtual GoodsStatus GoodsStatus { get; set; }
        public int GoodsTypeId { get; set; }
        [ForeignKey("GoodsTypeId")]
        public virtual GoodsType GoodsType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
