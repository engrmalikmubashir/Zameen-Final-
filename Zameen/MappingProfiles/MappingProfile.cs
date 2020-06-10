using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zameen.Controllers.Resources;
using Zameen.Models;

namespace Zameen.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityResources>();
        }
    }
}
