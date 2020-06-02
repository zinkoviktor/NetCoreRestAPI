
using System.Collections.Generic;

namespace Common.Converter
{
    public interface IConverter<T1, T2>
    {
        T2 ConvertTo(T1 t1);
        ICollection<T2> ConvertTo(ICollection<T1> t1);
        T1 ConvertFrom(T2 t2);
        ICollection<T1> ConvertFrom(ICollection<T2> t2);
    }
}
