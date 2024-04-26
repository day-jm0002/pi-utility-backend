using System.Data;

namespace Infra.Converter
{
    internal interface IConverterFromDataReader<out T> where T : new()
    {
        T ConvertFromDataReader(IDataReader dr);
    }
}
