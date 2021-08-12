using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class ProductsVM
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name Require")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Buy Price Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Data")]
        public string BuyPrice { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Sell Price Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Data")]
        public string SellPrice { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "profit Require")]
        public string Profit { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }


        [StringLength(50)]
        public string Weight { get; set; }

        
    }
}
