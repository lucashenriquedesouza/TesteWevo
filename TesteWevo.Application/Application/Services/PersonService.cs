using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.Contracts.Repositories;
using TesteWevo.Application.Domain.Contracts.Services;
using TesteWevo.Application.Domain.DTOs.Entities;
using TesteWevo.Application.Domain.DTOs.Requests;
using TesteWevo.Application.Domain.DTOs.Responses;
using TesteWevo.Application.Infra.Exceptions;

namespace TesteWevo.Application.Application.Services
{

    public class PersonService : IPersonService
    {

        private readonly ILogger<PersonService> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public PersonService(ILogger<PersonService> logger,
                             IMapper mapper,
                             IPersonRepository personRepository)
        {

            _logger = logger;
            _mapper = mapper;
            _personRepository = personRepository;

        }

        public async Task<PersonResponse> Insert(PersonSaveRequest request)
        {

            request.Id = await _personRepository
                                .Insert(_mapper.Map<PersonEntity>(request));

            if ((0).Equals(request.Id))
                throw new CustomApplicationException("Problemas na inserção do registro.", "ProblemasInsert");

            return _mapper.Map<PersonResponse>(request);

        }

        public async Task<PersonResponse> Update(PersonSaveRequest request)
        {

            var requestPerson = _mapper.Map<PersonEntity>(request);

            var databasePerson = await _personRepository.Select(request.Id);

            if (databasePerson is null)
                throw new CustomApplicationException("Registro inexistente.", "RegistroInexistente", HttpStatusCode.BadRequest);

            var person = requestPerson.Merge(databasePerson);

            if (!await _personRepository.Update(person))
                throw new CustomApplicationException("Problemas na alteração do registro.", "ProblemasUpdate");

            return _mapper.Map<PersonResponse>(person);

        }

        public async Task<PersonResponse> Select(int id)
        {

            var person = await _personRepository.Select(id);

            if (person is null)
                throw new CustomApplicationException("Registro inexistente.", "RegistroInexistente", HttpStatusCode.BadRequest);

            return _mapper.Map<PersonResponse>(person);

        }

        public async Task<List<PersonResponse>> SelectAll()
        {

            var persons = await _personRepository.SelectAll();

            if (!persons.Any())
                throw new CustomApplicationException("Não existem registros cadastrados.", "RegistroInexistente", HttpStatusCode.BadRequest);

            return _mapper.Map<List<PersonResponse>>(persons);

        }

        public async Task Delete(int id)
        {

            var person = await _personRepository.Select(id);

            if (person is null)
                throw new CustomApplicationException("Registro inexistente.", "RegistroInexistente", HttpStatusCode.BadRequest);

            if (!await _personRepository.Delete(person))
                throw new CustomApplicationException("Problemas na exclusão do registro.", "ProblemasDelete");

        }

    }

}
