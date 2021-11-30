using EstudoDDD.Domain.DTO;
using System.Threading.Tasks;

namespace EstudoDDD.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}
