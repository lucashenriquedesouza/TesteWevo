using System;
using TesteWevo.Application.Domain.DTOs.Entities;
using TesteWevo.Application.Domain.Enums;

namespace TesteWevo.Service.Mock.DTOs
{

    public class PersonEntityMock
    {

        protected PersonEntityMock()
        {

        }

        public static PersonEntity GetOk => new PersonEntity()
        {
            CPF = "123.456.789-00",
            DataNascimento = DateTime.Now,
            Email = "Teste@Teste.com",
            Id = 1,
            Nome = "teste",
            Sexo = Gender.Male,
            Telefone = "(11) 91234-5678"
        };

    }

}
