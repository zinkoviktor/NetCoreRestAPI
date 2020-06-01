
namespace Common.Converter
{
    public interface IConverter<T1, T2>
    {
        T2 ConvertTo(T1 t1);
        T1 ConvertFrom(T2 t2);
    }
}
