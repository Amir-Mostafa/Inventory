using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class ShokakOperation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }


        [StringLength(50)]
        public string Creditor { get; set; }

        [StringLength(50)]
        public string Debtor { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public int OrderId { get; set; }

        //[ForeignKey("OrderId")]
        //public virtual Orders Order { get; set; }

    }
}
