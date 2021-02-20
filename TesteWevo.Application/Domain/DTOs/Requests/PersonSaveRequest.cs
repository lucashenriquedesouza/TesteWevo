using System;
using System.Text.Json.Serialization;
using TesteWevo.Application.Domain.Enums;

namespace TesteWevo.Application.Domain.DTOs.Requests
{

    public class PersonSaveRequest
    {

        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Gender Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

    }

}
