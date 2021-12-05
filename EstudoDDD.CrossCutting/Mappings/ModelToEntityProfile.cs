using AutoMapper;
using EstudoDDD.Domain.Entities;
using EstudoDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();

            CreateMap<UfModel, UfEntity>().ReverseMap();

            CreateMap<MunicipioModel, MunicipioEntity>().ReverseMap();

            CreateMap<CepModel, CepEntity>().ReverseMap();
        }
    }
}
