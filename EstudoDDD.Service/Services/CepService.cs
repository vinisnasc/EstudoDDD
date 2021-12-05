using AutoMapper;
using EstudoDDD.Domain.DTO.CEP;
using EstudoDDD.Domain.Entities;
using EstudoDDD.Domain.Interfaces.Services.Cep;
using EstudoDDD.Domain.Models;
using EstudoDDD.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private IMapper _mapper;

        public CepService(ICepRepository cepRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = cepRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CepDtoCreateResult>(result);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(cep);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CepDtoUpdateResult>(result);
        }
    }
}
