using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanLite.Core.Common
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public Error? Error { get; set; }

        public static Result<T> Success(T? value) => new() { Value = value };

        public static Result<T> Fail(Error? error) => new() { Error = error };

        public static Result<T> Fail(string errorDescription)
        {
            return new()
            {
                Error = new Error { Description = errorDescription }
            };
        }

        public bool IsSuccess => Error == null;
    }

    public class Error
    {
        public string? Description { get; set; }
    }

    public class VoidResult
    { }
}
