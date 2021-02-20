using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Context;
using System;
using System.Net;
using System.Threading.Tasks;
using TesteWevo.Application.Domain.DTOs.Responses;
using TesteWevo.Application.Infra.Exceptions;

namespace TesteWevo.API.Controllers
{

    public abstract class BaseController<TController, IService> : ControllerBase
    {

        protected readonly ILogger<TController> _logger;
        protected readonly IService _service;

        protected BaseController(ILogger<TController> logger,
                                 IService service)
        {

            _logger = logger;
            _service = service;

        }

        public async Task<IActionResult> Execute<TIn, TOut>(TIn data, string operation, Func<TIn, Task<TOut>> funcTask, AbstractValidator<TIn> validator = null, string validatorRuleSet = "")
        {

            using (LogContext.PushProperty("data", JsonConvert.SerializeObject(data)))
            {

                _logger.LogInformation($"Inicio - {operation}");

                try
                {

                    if (!(validator is null))
                        validator.Validate(data, options => options.IncludeRuleSets(validatorRuleSet).IncludeRulesNotInRuleSet().ThrowOnFailures());

                    var result = await funcTask.Invoke(data);

                    return Ok(BaseResponse<TOut>.GetSuccess(result));

                }
                catch (ValidationException vEx)
                {

                    _logger.LogError(vEx.Message, $"Erro - {operation}");

                    return StatusCode((int)HttpStatusCode.BadRequest, BaseResponse<object>.GetError(vEx.Errors));

                }
                catch (CustomApplicationException caEx)
                {

                    _logger.LogError(caEx.Message, $"Erro - {operation}");

                    return StatusCode((int)caEx.StatusCode, BaseResponse<object>.GetError(caEx.Code, caEx.Message));

                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, $"Erro - {operation}");

                    return StatusCode((int)HttpStatusCode.InternalServerError, BaseResponse<object>.GetError("ErroGeral", ex.Message));

                }
                finally
                {

                    _logger.LogInformation($"Fim - {operation}");

                }

            }

        }

    }

}
