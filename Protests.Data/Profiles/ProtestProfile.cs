using System;
using AutoMapper;
using Protests.Data.Entities;
using Protests.Data.Models;

namespace Protests.Data.Profiles
{
    public class ProtestProfile : Profile
    {
        public ProtestProfile()
        {
            CreateMap<Protest, ProtestDetail>();
        }
    }
}