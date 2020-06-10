using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zameen.Models.ViewModels
{
    public class ClientViewModel
    {

        public Client Client { get; set; }

        [Display(Name = "Country")]
        public IEnumerable<Country> Countries { get; set; }

        [Display(Name = "City")]
        public IEnumerable<City> Cities { get; set; }

    }
}
