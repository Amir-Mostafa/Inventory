using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Entity
{
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string BankNumber { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<BuyOrder>BuyOrders { get; set; }

        public virtual ICollection<BuyOperations> BuyOperations { get; set; }




    }
}
