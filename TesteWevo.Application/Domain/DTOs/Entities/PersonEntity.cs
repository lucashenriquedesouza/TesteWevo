using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TesteWevo.Application.Domain.Enums;

namespace TesteWevo.Application.Domain.DTOs.Entities
{

    [Table("Person")]
    public class PersonEntity
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [JsonIgnore]
        private Gender? _sexo;
        public Gender? Sexo
        {
            get
            {

                return (0).Equals((int)_sexo) ? null : _sexo;
            }
            set
            {

                _sexo = value;

            }
        }

        [JsonIgnore]
        private DateTime? _dataNascimento;
        public DateTime? DataNascimento
        {
            get
            {

                return (DateTime.MinValue).Equals(_dataNascimento) ? null : _dataNascimento;
            }
            set
            {

                _dataNascimento = value;

            }
        }

        public PersonEntity Merge(PersonEntity source)
        {

            JObject jsonSource = JObject.Parse(JsonConvert.SerializeObject(source));

            JObject jsonDestination = JObject.Parse(JsonConvert.SerializeObject(this,
                                                    new JsonSerializerSettings
                                                    {
                                                        NullValueHandling = NullValueHandling.Ignore
                                                    }));

            jsonSource.Merge(jsonDestination, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });

            return JsonConvert.DeserializeObject<PersonEntity>(jsonSource.ToString());

        }

    }

}
