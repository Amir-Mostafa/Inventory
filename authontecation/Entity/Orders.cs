using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    
    public class Orders
    {
        
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [StringLength(50)]
        public string Total { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Paid { get; set; }

        [StringLength(50)]
        public string Remaind { get; set; }

        [StringLength(50)]
        public string Weight { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //[NotMapped]
        public virtual ICollection<ShokakOperation> ShokakOperations { get; set; }
        public virtual ICollection<Operations>Operations { get; set; }



    }
}
