using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.Contracts.Repositories;
using TesteWevo.Application.Domain.DTOs;
using TesteWevo.Application.Domain.DTOs.Entities;

namespace TesteWevo.Application.Infra.Repositories
{

    public class PersonRepository : BaseRepository, IPersonRepository
    {

        public PersonRepository(IOptions<Configurations> configurations)
            : base(configurations)
        {

        }

        public async Task<int> Insert(PersonEntity person) =>
            await GetSQLiteConn()
                    .InsertAsync(person);

        public async Task<bool> Update(PersonEntity person) =>
            await GetSQLiteConn()
                    .UpdateAsync(person);

        public async Task<bool> Delete(PersonEntity person) =>
            await GetSQLiteConn()
                    .DeleteAsync(person);

        public async Task<PersonEntity> Select(int id) =>
            await GetSQLiteConn()
                    .GetAsync<PersonEntity>(id);

        public async Task<IEnumerable<PersonEntity>> SelectAll() =>
            await GetSQLiteConn()
                    .GetAllAsync<PersonEntity>();
    }

}
