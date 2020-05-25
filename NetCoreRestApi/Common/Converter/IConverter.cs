
namespace Common.Converter
{
    public interface IConverter<T1, T2>
    {
        T1 ConvertTo(T2 convertFrom);
        T2 ConvertFrom(T1 convertTo);
    }
}
