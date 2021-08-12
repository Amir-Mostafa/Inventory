using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class BuyOrderVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date Require")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "User Name Require")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Total Require")]
        public string Total { get; set; }


        public int SupplierId { get; set; }
        public string SupplierName { get; set; }


    }
}
