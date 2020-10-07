using AngASPNETCOREBackend.Dtos;
using AngASPNETCOREBackend.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersReadDto>();
            CreateMap<UsersCreateDto, Users>();
            CreateMap<UsersUpdateDto, Users >();
        }
    }
}
