using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models
{
    public class City
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter City!")]
        [Display(Name = "City")]
        public string Name { get; set; }

        public Country Country { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Country")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

    }
}
