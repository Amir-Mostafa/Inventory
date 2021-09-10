using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class BuyOperationsVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Amount Require")]
        public string ProductAmout { get; set; }

        [Required(ErrorMessage = "Product Price Require")]
        [DataType(DataType.Currency,ErrorMessage ="Invalid Data")]
        public string ProductPrice { get; set; }
        [Required(ErrorMessage = "Date Require")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Total Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Data")]
        public string Total { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "order ID Require")]
        public int orderId { get; set; }
        [Required(ErrorMessage = "supplier ID Require")]
        public int supplierId { get; set; }
        [Required(ErrorMessage = "product ID Require")]
        public int productId { get; set; }
        public string name { get; set; }




    }
}
