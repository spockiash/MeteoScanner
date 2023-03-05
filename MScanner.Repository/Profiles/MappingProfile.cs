using AutoMapper;
using MScanner.Data.Entities;
using MScanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Repository.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SensorDataEntity, SensorDataModel>().ReverseMap();
        }
    }
}
