using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MobileForm, Mobile>();
            
        }
    }
}
