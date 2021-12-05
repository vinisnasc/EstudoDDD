using AutoMapper;
using EstudoDDD.Domain.DTO.CEP;
using EstudoDDD.Domain.DTO.Municipio;
using EstudoDDD.Domain.DTO.Uf;
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
            // User
            CreateMap<UserDtoCreate, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();

            // Uf
            CreateMap<UfDto, UfEntity>().ReverseMap();

            // Municipio
            CreateMap<MunicipioDto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoCompleto, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>().ReverseMap();
            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>().ReverseMap();

            // Cep
            CreateMap<CepDto, CepEntity>().ReverseMap();
            CreateMap<CepDtoCreateResult, CepEntity>().ReverseMap();
            CreateMap<CepDtoUpdateResult, CepEntity>().ReverseMap();
        }
    }
}
