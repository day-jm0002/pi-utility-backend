using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.SmartBrain.Response
{
    public class CarteiraRentabilidadeResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public IList<CarteiraRentabilidade> Rentabilidades { get; set; }
    }

    public class CarteiraRentabilidade
    {
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public decimal CotaCarteira { get; set; }
        public decimal CotaIndexador1 { get; set; }
        public decimal CotaIndexador2 { get; set; }
        public decimal CotaIndexador3 { get; set; }
        public decimal CotaIndexador4 { get; set; }
        public decimal CotaIndexador5 { get; set; }
    }
}
