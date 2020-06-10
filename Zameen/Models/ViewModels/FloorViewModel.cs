using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models.ViewModels
{
    public class FloorViewModel
    {
        public Floor Floor { get; set; }

        [Display(Name = "Building")]
        public IEnumerable<Building> Buildings { get; set; }
    }
}
