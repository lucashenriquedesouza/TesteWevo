using System.Collections.Generic;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.DTOs.Requests;
using TesteWevo.Application.Domain.DTOs.Responses;

namespace TesteWevo.Application.Domain.Contracts.Services
{

    public interface IPersonService
    {

        Task Delete(int id);
        Task<PersonResponse> Insert(PersonSaveRequest request);
        Task<PersonResponse> Select(int id);
        Task<List<PersonResponse>> SelectAll();
        Task<PersonResponse> Update(PersonSaveRequest request);

    }

}
