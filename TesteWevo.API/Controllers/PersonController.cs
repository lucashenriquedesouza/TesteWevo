using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.Contracts.Services;
using TesteWevo.Application.Domain.DTOs.Requests;
using TesteWevo.Application.Domain.DTOs.Requests.Validators;

namespace TesteWevo.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : BaseController<PersonController, IPersonService>
    {

        public PersonController(ILogger<PersonController> logger,
                                IPersonService service)
            : base(logger, service)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            await Execute(null,
                          "Obter Pessoas",
                          async (object a) => { return await _service.SelectAll(); });

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) =>
            await Execute(id,
                          "Obter Pessoa",
                          async (int id) => { return await _service.Select(id); });

        [HttpPost()]
        public async Task<IActionResult> Post(PersonSaveRequest request) =>
            await Execute(request,
                          "Incluir Pessoa",
                          async (PersonSaveRequest request) => { return await _service.Insert(request); },
                          new PersonSaveRequestValidator(),
                          "Insert");

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, PersonSaveRequest request)

        {

            request.Id = id;

            return await Execute(request,
                                 "Alterar Pessoa",
                                 async (PersonSaveRequest request) => { return await _service.Update(request); },
                                 new PersonSaveRequestValidator(),
                                 "Update");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) =>
            await Execute(id,
                          "Deletar Pessoa",
                          async (int id) => { await _service.Delete(id); return id; });

    }

}