using Infra.Converter;
using Infra.Result;
using System;
using System.Data;
using System.Text;

namespace Infra
{
    internal class FundosDriveAMnetConverter : IConverterFromDataReader<FundosDriveAMnet>
    {
        public FundosDriveAMnet ConvertFromDataReader(IDataReader dr)
        {
            return new FundosDriveAMnet
            {               
            };
        }
    }
}
