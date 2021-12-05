using AutoMapper;
using EstudoDDD.Domain.DTO.CEP;
using EstudoDDD.Domain.DTO.Municipio;
using EstudoDDD.Domain.DTO.Uf;
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
            // User
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();

            // Uf
            CreateMap<UfModel, UfDto>().ReverseMap();

            // Municipio
            CreateMap<MunicipioModel, MunicipioDto>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>().ReverseMap();

            // Cep
            CreateMap<CepModel, CepDto>().ReverseMap();
            CreateMap<CepModel, CepDtoCreate>().ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>().ReverseMap();
        }
    }
}
