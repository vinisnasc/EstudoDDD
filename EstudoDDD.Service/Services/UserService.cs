using AutoMapper;
using EstudoDDD.Domain.DTO.User;
using EstudoDDD.Domain.Entities;
using EstudoDDD.Domain.Interfaces;
using EstudoDDD.Domain.Interfaces.Services.User;
using EstudoDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstudoDDD.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDtoCreate> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDtoCreate>(entity); // TODO verificar esse metodo
        }

        public async Task<IEnumerable<UserDtoCreate>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDtoCreate>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);

            var entity = _mapper.Map<UserEntity>(model);

            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(entity);
        }

        public async Task <UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);

            var entity = _mapper.Map<UserEntity>(model);

            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(entity);
        }
    }
}
