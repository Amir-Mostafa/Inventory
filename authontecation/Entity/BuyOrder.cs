using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class BuyOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string Total { get; set; }


        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Suppliers Suppliers { get; set; }


        public virtual ICollection<BuyOperations>BuyOperations { get; set; }
    }
}
