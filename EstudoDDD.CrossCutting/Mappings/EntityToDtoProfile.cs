using AutoMapper;
using EstudoDDD.Domain.DTO.User;
using EstudoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDtoCreate, UserEntity>().ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
        }
    }
}
