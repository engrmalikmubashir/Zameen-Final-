using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models
{
    public class Shop
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Description!")]
        [Display(Name = "Shop")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Area!")]
        [Display(Name = "Area")]
        [StringLength(255)]
        public string Area { get; set; }

        public Floor Floor { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Floor")]
        [ForeignKey("Floor")]
        public int FloorId { get; set; }

        public Building Building { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Building")]
        [ForeignKey("Building")]
        public int BuildingId { get; set; }

    }

}
