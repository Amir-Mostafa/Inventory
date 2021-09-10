using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class ShokakOperationVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Date Require")]
        public DateTime Date { get; set; }
        [StringLength(50)]

        [Required(ErrorMessage = "Creditor Require")]
        [DataType(DataType.Currency,ErrorMessage ="Invalid Data")]
        public string Creditor { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Debtor Require")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Data")]
        public string Debtor { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        public int ClientId { get; set; }
        public int OrderId { get; set; }

        public string total { get; set; }
    }
}
