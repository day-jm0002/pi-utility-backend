using Proxy.SmartBrain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SmartBrain.Interface
{
    public interface ISmartBrainProxy
    {
        Task<dynamic> Autenticar();

        Task ObterRentabilidade();
    }
}
