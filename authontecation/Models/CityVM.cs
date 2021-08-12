using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
    public class CityVM
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name Require")]
        [MinLength(3, ErrorMessage = "Minimam Length 3 character")]
        [MaxLength(20, ErrorMessage = "Max Length 20 character")]
        public string Name { get; set; }
    }
}
