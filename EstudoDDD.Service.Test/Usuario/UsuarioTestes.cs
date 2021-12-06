using EstudoDDD.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<UserDto> ListaUserDto = new();
        public UserDto UserDto;
        public UserDtoCreate UserDtoCreate;
        public UserDtoCreateResult UserDtoCreateResult;
        public UserDtoUpdate UserDtoUpdate;
        public UserDtoUpdateResult UserDtoUpdateResult;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                UserDto dto = new()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                };
                ListaUserDto.Add(dto);
            }

            UserDto userDto = new()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            UserDtoCreate userDtoCreate = new()
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            UserDtoCreateResult userDtoCreateResult = new()
            {
                Id = IdUsuario,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now
            };

            UserDtoUpdate userDtoUpdate = new()
            {
                Id = IdUsuario,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            UserDtoUpdateResult userDtoUpdateResult = new()
            {
                Id = IdUsuario,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                UpdateAt = DateTime.Now 
            };
        }
    }
}
