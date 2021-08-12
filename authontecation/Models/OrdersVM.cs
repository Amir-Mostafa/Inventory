using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class OrdersVM
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date Require")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime Date { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Total Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Date")]

        public string Total { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "User Name Require")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Paid Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Date")]
        public string Paid { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Remaind Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Date")]
        public string Remaind { get; set; }

        [StringLength(50)]
        public string Weight { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }



    }
}
