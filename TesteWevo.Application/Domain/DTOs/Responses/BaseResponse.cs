using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TesteWevo.Application.Domain.DTOs.Responses
{

    public class BaseResponse<T>
    {

        public bool Success { get; set; }

        public T Data { get; set; }

        public IEnumerable<Notification> Notifications { get; set; }

        public static BaseResponse<T> GetSuccess(T data) =>
            new BaseResponse<T>()
            {
                Success = true,
                Data = data,
                Notifications = null
            };

        public static BaseResponse<object> GetError(string code, string message) =>
            new BaseResponse<object>()
            {
                Success = false,
                Data = null,
                Notifications = new List<Notification>() { new Notification(code, message) }
            };

        public static BaseResponse<object> GetError(IEnumerable<ValidationFailure> failures) =>
            new BaseResponse<object>()
            {
                Success = false,
                Data = null,
                Notifications = failures.Select(failure => new Notification(failure.ErrorCode, failure.ErrorMessage))
            };

    }

    public class Notification
    {

        public string Code { get; set; }
        public string Message { get; set; }

        public Notification(string code, string message)
        {

            Code = code;
            Message = message;

        }

    }

}
