using Common.Converter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.Converters
{
    public abstract class BaseConvertor<T1, T2> : IConverter<T1, T2>
    {
        public abstract Expression<Func<T1, T2>> ConvertToExpression { get; }
        public abstract Expression<Func<T2, T1>> ConvertFromExpression { get; }

        public virtual T2 ConvertTo(T1 t1)
        {
            if (t1 == null)
            {
                return default;
            }

            var _convertingFunction = ConvertToExpression.Compile();
            return _convertingFunction(t1);
        }

        public virtual ICollection<T2> ConvertTo(ICollection<T1> t1Collection)
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

            var _convertingFunction = ConvertFromExpression.Compile();
            return  _convertingFunction(t2);           
        }

        public virtual ICollection<T1> ConvertFrom(ICollection<T2> t2Collection)
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
