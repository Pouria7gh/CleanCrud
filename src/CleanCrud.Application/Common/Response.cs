using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Common
{
    public class Response<T>
    {
        public bool Succeeded { get; private set; }
        public string? Error { get; private set; }
        public T? Data { get; private set; }

        public static Response<T> Success(T data) => new()
        {
            Succeeded = true,
            Data = data
        };

        public static Response<T> Fail(string error) => new()
        {
            Succeeded = false,
            Error = error,
            Data = default
        };
    }
}
