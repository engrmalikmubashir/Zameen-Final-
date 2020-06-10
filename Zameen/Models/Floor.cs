using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models
{
    public class Floor
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Description!")]
        [Display(Name = "Floor")]
        [StringLength(255)]
        public string Name { get; set; }

        public Building Building { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Building")]
        [ForeignKey("Building")]
        public int BuildingId { get; set; }

    }

}
