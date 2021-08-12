using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class Operations
    {
        [Key]
        public int Id { get; set; }

        public string productAmount { get; set; }
        public string productPrice { get; set; }

        public string Toala { get; set; }

        public string Profit { get; set; }

        public DateTime date { get; set; }

        public string Notes { get; set; }

        public string Weight { get; set; }


        public int OrderId { get; set; }

        //[ForeignKey("OrderId")]
        //public virtual Orders Orders { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }


        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }

    }
}
