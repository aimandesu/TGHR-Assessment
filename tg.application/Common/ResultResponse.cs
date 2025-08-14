using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tg.application.Features.Following;

namespace tg.application.Common
{
    public class ResultResponse<TSuccess, TFailure>
    {
        public bool IsSuccess { get; set; }
        public TSuccess? SuccessData { get; set; } = default;
        public TFailure? FailureData { get; set; } = default;

        public static ResultResponse<TSuccess, TFailure> Success(TSuccess data) => new()
        {
            IsSuccess = true,
            SuccessData = data
        };

        public static ResultResponse<TSuccess, TFailure> Fail(TFailure data) => new()
        {
            IsSuccess = false,
            FailureData = data,

        };
    }

    public class Result
    {
        public bool IsSuccess { get; }
        public Error Error { get; }

        public bool IsFailure => !IsSuccess;

        private Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            return new Result(true, Error.None);
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }
    }
    
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public Error Error { get; }
        public T Value { get; }
    
        public bool IsFailure => !IsSuccess;
    
        private Result(bool isSuccess, T value, Error error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }
    
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, Error.None);
        }
    
        public static Result<T> Failure(Error error)
        {
            return new Result<T>(false, default!, error);
        }
    }
    
}