using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kernel
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T Value { get; }
        public string Error { get; }

        protected Result(bool Success, T Val, string Err)
        {
            IsSuccess = Success;
            Value = Val;
            Error = Err;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, Err: null);   
        public static Result<T> Failure(string err) => new Result<T>(false, Val: default, err);


    }
}
