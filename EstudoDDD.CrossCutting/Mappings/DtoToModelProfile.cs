using AutoMapper;
using EstudoDDD.Domain.DTO.User;
using EstudoDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<UserModel, UserDtoCreate>().ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}
