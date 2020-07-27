using System;
using AutoMapper;
using Fights.Data.Entities;
using Fights.Data.Models;

namespace Fights.Data.Profiles
{
    public class ProtestProfile : Profile
    {
        public ProtestProfile()
        {
            CreateMap<Protest, ProtestDetail>();
        }
    }
}