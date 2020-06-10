using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models
{
    public class Client
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name!")]
        [Display(Name = "Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Area!")]
        [Display(Name = "Address")]
        [StringLength(255)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Email!")]
        [Display(Name = "Email")]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter CNIC!")]
        [Display(Name = "CNIC")]
        [StringLength(15)]
        public string Cnic { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile!")]
        [Display(Name = "Mobile")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Landline!")]
        [Display(Name = "Landline")]
        [StringLength(20)]
        public string Landline { get; set; }


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
