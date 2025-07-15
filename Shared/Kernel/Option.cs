using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kernel
{
    public struct Option<T>
    {
        private readonly T _value;
        public bool IsSome { get; }
        public bool IsNone => !IsSome;

        public T Value => IsSome ? _value : throw new InvalidOperationException("No value present");

        private Option(T value)
        {
            _value = value;
            IsSome = true;
        }

        public static Option<T> Some(T Value) => new Option<T>(Value);
        public static Option<T> None() => new Option<T>();

        public TResult Match<TResult>(
                Func<T, TResult> Some, 
                Func<TResult> None
            ) => IsSome ? Some(_value) : None(); 

    }
}
