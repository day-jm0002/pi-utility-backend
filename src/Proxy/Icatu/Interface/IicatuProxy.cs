using Proxy.Icatu.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Icatu.Interface
{
    public interface IIcatuProxy
    {
        Task<ResponseIcatu> ObterGrauParentesco();
    }
}
