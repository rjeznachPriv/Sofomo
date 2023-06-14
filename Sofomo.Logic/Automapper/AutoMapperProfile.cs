using AutoMapper;
using Sofomo.Domain.Entities;
using Sofomo.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofomo.Logic.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LocationDTO, Location>();
            CreateMap<Location, LocationDTO>();
        }
    }
}
