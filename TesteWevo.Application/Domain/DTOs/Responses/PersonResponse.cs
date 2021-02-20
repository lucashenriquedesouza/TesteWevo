using System;
using System.Collections.Generic;
using System.Text;
using TesteWevo.Application.Domain.Enums;

namespace TesteWevo.Application.Domain.DTOs.Responses
{

    public class PersonResponse
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Gender Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

    }

}
