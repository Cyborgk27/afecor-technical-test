using System.Net;

namespace TT.Application.Commons.Bases
{
    public static class ResponseFactory
    {
        public static BaseResponse<T> Success<T>(T data, string message = "Operación exitosa", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new BaseResponse<T>
            {
                IsSuccess = true,
                StatusCode = (int)statusCode,
                Message = message,
                Data = data
            };
        }

        public static BaseResponse<T> Created<T>(T data, string message = "Recurso creado exitosamente")
        {
            return new BaseResponse<T>
            {
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.Created,
                Message = message,
                Data = data
            };
        }

        public static BaseResponse<T> Fail<T>(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, List<string>? errors = null)
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                StatusCode = (int)statusCode,
                Message = message,
                Errors = errors ?? new List<string>()
            };
        }

        public static BaseResponse<T> NotFound<T>(string message = "Recurso no encontrado")
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                StatusCode = (int)HttpStatusCode.NotFound,
                Message = message
            };
        }
    }
}
