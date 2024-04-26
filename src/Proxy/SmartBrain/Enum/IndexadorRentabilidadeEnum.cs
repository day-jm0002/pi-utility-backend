using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Proxy.SmartBrain.Enum
{
    public enum IndexadorRentabilidadeEnum
    {            
        [Description("CDI")]
        Cdi = 1,
        [Description("IBOVESPA")]
        Ibovespa = 2,
        [Description("Dolar Comercial")]
        DolarComercial = 3,
        [Description("IGPM")]
        IGPM = 4,
        [Description("IPCA")]
        IPCA = 7,
        [Description("Carteira")]
        Carteira = 12812134
    }
}
