using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Country!")]
        [Display(Name = "Country")]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
