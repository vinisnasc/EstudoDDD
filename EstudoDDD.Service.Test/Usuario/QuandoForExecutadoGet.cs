using EstudoDDD.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EstudoDDD.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _service;
        // O Mock serve para criar uma "copia" da IUserService
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GET")]
        public async Task E_POSSIVEL_EXECUTAR_METODO_GET()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(UserDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
        }
    }
}
