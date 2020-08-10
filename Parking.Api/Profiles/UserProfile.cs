using AutoMapper;
using Parking.Api.Requests;
using Parking.Data.Entities;
using Parking.Data.Models;

namespace Parking.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationRequest, AppUser>().ReverseMap();
            CreateMap<UserDetail, AppUser>().ReverseMap();
        }
    }
}