using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError
        {
            get { return !IsSuccess; }
        }
        public EnumStatusCode StatusCode { get; set; }

        public static Result<T> SuccessResult(string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
        {
            return new Result<T> { Message = message, IsSuccess = true, StatusCode = statusCode };
        }

        public static Result<T> SuccessResult(T data, string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
        {
            return new Result<T> { Message = message, IsSuccess = true, StatusCode = statusCode, Data = data };
        }

        public static Result<T> FailureResult(string message = "Fail.", EnumStatusCode statusCode = EnumStatusCode.BadRequest)
        {
            return new Result<T> { Message = message, IsSuccess = false, StatusCode = statusCode };
        }

        public static Result<T> FailureResult(Exception ex)
        {
            return new Result<T> { Message = ex.ToString(), IsSuccess = false, StatusCode = EnumStatusCode.InternalServerError };
        }

        public static Result<T> ExecuteResult(int result, EnumStatusCode successStatusCode = EnumStatusCode.Success, EnumStatusCode failureStatusCode = EnumStatusCode.BadRequest)
        {
            return result > 0 ? Result<T>.SuccessResult(statusCode: successStatusCode)
                : Result<T>.FailureResult(statusCode: failureStatusCode);
        }
    }

    public enum EnumStatusCode
    {
        None,
        Success = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        NotFound = 404,
        Conflict = 409,
        Locked = 423,
        InternalServerError = 500
    }
}