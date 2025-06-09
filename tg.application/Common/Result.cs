using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.application.Common
{
    public class Result<TSuccess, TFailure>
    {
        public bool IsSuccess { get; set; }
        public TSuccess? SuccessData { get; set; } = default;
        public TFailure? FailureData { get; set; } = default;

        public static Result<TSuccess, TFailure> Success(TSuccess data) => new()
        {
            IsSuccess = true,
            SuccessData = data
        };

        public static Result<TSuccess, TFailure> Fail(TFailure data) => new()
        {
            IsSuccess = false,
            FailureData = data,

        };
    }
}