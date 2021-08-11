using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }


        public virtual ICollection<Orders> Orders { get; set; }

       public virtual ICollection<ShokakOperation> ShokakOperations { get; set; }

        public virtual ICollection<Operations> Operations { get; set; }

    }
}
