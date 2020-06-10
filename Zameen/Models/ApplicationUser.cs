using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Zameen.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please Enter Office Phone")]
        [Display(Name = "Office Phone")]
        [StringLength(20)]
        public string PhoneNumber2 { get; set; }

        [NotMapped]
        public bool IsAdmin { get; set; }

    }
}
