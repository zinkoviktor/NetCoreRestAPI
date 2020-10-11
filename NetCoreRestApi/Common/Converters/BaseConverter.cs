using Common.Converter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.Converters
{
    public abstract class BaseConverter<T1, T2> : IConverter<T1, T2>
    {
        public abstract Expression<Func<T1, T2>> ConvertToExpression { get; }
        public abstract Expression<Func<T2, T1>> ConvertFromExpression { get; }
        private Func<T1, T2> _convertingToFunction;
        private Func<T2, T1> _convertingFromFunction;

        public BaseConverter()
        {
            _convertingToFunction = ConvertToExpression.Compile();
            _convertingFromFunction = ConvertFromExpression.Compile();
        }

        public virtual T2 ConvertTo(T1 t1)
        {
            if (t1 == null)
            {
                return default;
            }
            return _convertingToFunction(t1);
        }

        public virtual IEnumerable<T2> ConvertTo(IEnumerable<T1> t1Collection)
        {
            var collection = new List<T2>();

            if (t1Collection == null)
            {
                return collection;
            }

            foreach (var t1 in t1Collection)
            {
                collection.Add(ConvertTo(t1));
            }

            return collection;
        }

        public virtual T1 ConvertFrom(T2 t2)
        {
            if (t2 == null)
            {
                return default;
            }

            return _convertingFromFunction(t2);
        }

        public virtual IEnumerable<T1> ConvertFrom(IEnumerable<T2> t2Collection)
        {
            var collection = new List<T1>();

            if (t2Collection == null)
            {
                return collection;
            }

            foreach (var t2 in t2Collection)
            {
                collection.Add(ConvertFrom(t2));
            }

            return collection;
        }
    }
}
