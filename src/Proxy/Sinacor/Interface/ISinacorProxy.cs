using Proxy.Sinacor.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Sinacor.Interface
{
    public  interface ISinacorProxy
    {
        Task<SinacorProxyResult> Autenticar();
    }
}
