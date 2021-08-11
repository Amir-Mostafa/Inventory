using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string BuyPrice { get; set; }

        [StringLength(50)]
        public string SellPrice { get; set; }


        [StringLength(50)]
        public string Profit { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }


        [StringLength(50)]
        public string Weight { get; set; }

        public virtual ICollection<Operations> Operations { get; set; }

        public virtual ICollection<BuyOperations> BuyOperations { get; set; }
    }
}
