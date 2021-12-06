using EstudoDDD.Domain.DTO.User;
using EstudoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDtoCreate> Get(Guid id);
        Task<IEnumerable<UserDtoCreateResult>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
