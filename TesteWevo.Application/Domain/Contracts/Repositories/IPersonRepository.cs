using System.Collections.Generic;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.DTOs.Entities;

namespace TesteWevo.Application.Domain.Contracts.Repositories
{

    public interface IPersonRepository
    {

        Task<bool> Delete(PersonEntity person);
        Task<int> Insert(PersonEntity person);
        Task<PersonEntity> Select(int id);
        Task<IEnumerable<PersonEntity>> SelectAll();
        Task<bool> Update(PersonEntity person);

    }

}
