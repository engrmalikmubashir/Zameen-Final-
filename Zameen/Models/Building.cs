using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models
{
    public class Building
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Description!")]
        [Display(Name = "Building")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address!")]
        [Display(Name = "Address")]
        [StringLength(255)]
        public string Address { get; set; }

        public Country Country { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Country")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public City City { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select City")]
        [ForeignKey("City")]
        public int CityId { get; set; }

    }
}
