using EstudoDDD.Data.Context;
using EstudoDDD.Data.Implementations;
using EstudoDDD.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EstudoDDD.Data.Test
{
    // Interface IClassFixture é uma implementação para ter acesso ao DB de teste
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new(context);
                UserEntity _entity = new()
                {
                    // Biblioteca Faker, para criar dados fakes aleatórios
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                #region Teste do Insert
                var _registroCriado = await _repositorio.InsertAsync(_entity);

                // Assert é para dizer o valor esperado
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
                #endregion

                #region Teste do Update
                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);
                #endregion

                #region Teste do Exist
                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);
                #endregion

                #region Teste do Select
                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);
                #endregion

                #region Teste do GetAll
                var _todosRegistros = await _repositorio.SelectAsync(); 
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);
                #endregion

                #region Teste do Delete
                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);
                #endregion

                #region Teste do FindByLogin
                var _usuarioPadrao = await _repositorio.FindByLogin("vini.souza00@gmail.com");
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("vini.souza00@gmail.com", _usuarioPadrao.Email);
                #endregion
            }
        }
    }
}
