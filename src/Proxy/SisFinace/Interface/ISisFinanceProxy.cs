using Proxy.SisFinace.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SisFinace
{
    public interface ISisFinanceProxy
    {
        Task<SisfinanceResponse> Autenticar();
    }
}
