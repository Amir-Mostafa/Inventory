using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class Suppliers
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Require")]
        [MinLength(3,ErrorMessage ="Minimam Length 3 character")]
        [MaxLength(20, ErrorMessage = "Max Length 20 character")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Address Require")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Require")]
        public string Phone { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
    }
}
