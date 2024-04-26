using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.PortalInvestimentos.Util
{
    public class Parametros
    {
        public string? ChaveLiberacao { get; set; }
        public string? Funcionalidade { get; set; }
        public static string FundosRelacao(Parametros parametros)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(parametros);
        }

    }
}
