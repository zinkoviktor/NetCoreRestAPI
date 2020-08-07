using System.Collections.Generic;

namespace Common.Converter
{
    public interface IConverter<T1, T2>
    {
        T2 ConvertTo(T1 t1);
        IEnumerable<T2> ConvertTo(IEnumerable<T1> t1Collection);
        T1 ConvertFrom(T2 t2);
        IEnumerable<T1> ConvertFrom(IEnumerable<T2> t2Collection);
    }
}
