using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class OperationsVM
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount Require")]
        
        public string productAmount { get; set; }
        [Required(ErrorMessage = "Price Require")]
        public string productPrice { get; set; }

        [Required(ErrorMessage = "Total Require")]
        public string Total { get; set; }

        [Required(ErrorMessage = "Profit Require")]
        public string Profit { get; set; }

        [Required(ErrorMessage = "Date Require")]
        public DateTime date { get; set; }

        public string Notes { get; set; }

        public string Weight { get; set; }


        public int OrderId { get; set; }
        public int ClientId { get; set; }

        public int ProductId { get; set; }


    }
}
