using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models.ViewModels
{
    public class ShopViewModel
    {

        public Shop Shop { get; set; }

        [Display(Name = "Building")]
        public IEnumerable<Building> Buildings { get; set; }

        [Display(Name = "Floor")]
        public IEnumerable<Floor> Floors { get; set; }

    }
}
