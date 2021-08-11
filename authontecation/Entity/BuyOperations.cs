using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class BuyOperations
    {

        [Key]
        public int Id { get; set; }

        public string ProductAmout { get; set; }
        public string ProductPrice { get; set; }
        public DateTime Date { get; set; }
        public string Total { get; set; }
        public string Notes { get; set; }

        [ForeignKey("OrderId")]
        public virtual BuyOrder BuyOrder { get; set; }


        [ForeignKey("SupplierId")]
        public virtual Suppliers Suppliers { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }




    }
}
