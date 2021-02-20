using System.Collections.Generic;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.Contracts.Repositories;
using TesteWevo.Application.Domain.DTOs.Entities;
using TesteWevo.Service.Mock.DTOs;

namespace TesteWevo.Service.Mock.Repositories
{

    public class PersonRepositoryMock : IPersonRepository
    {

        public async Task<bool> Delete(PersonEntity person) => true;

        public async Task<int> Insert(PersonEntity person) => 1;

        public async Task<PersonEntity> Select(int id) => PersonEntityMock.GetOk;

        public async Task<IEnumerable<PersonEntity>> SelectAll() => new List<PersonEntity>() { PersonEntityMock.GetOk };

        public async Task<bool> Update(PersonEntity person) => true;

    }

}
