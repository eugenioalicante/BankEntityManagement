using BackEntityManagement.Helpers.Exceptions;
using Newtonsoft.Json;
using System;
using System.Net;

namespace BackEntityManagement.Infrastructure.Exceptions
{
    public static class ExceptionExtension
    {
        public static (int Status, string Message) CreateResponseMessage(this Exception exception)
        {
            var message = "Error interno del servidor. Mas info: " + (exception.InnerException != null ? exception.InnerException.Message : exception.Message);
            HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

            if (exception is BaseException)
            {
                var baseException = exception as BaseException;

                message = baseException.Message;
                StatusCode = baseException.StatusCode;
            }

            Error error = new Error()
            {
                RespuestaHTTP = StatusCode,
                Id = (int)StatusCode,
                Descripcion = message
            };

            string serializedResponse = JsonConvert.SerializeObject(error);

            return ((int)StatusCode, serializedResponse);
        }
    }
}
