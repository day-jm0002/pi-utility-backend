using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Icatu.Response
{
    public class GrauParentescoResponse
    {
        public int CodigoParentesco { get; set; }
        public string NomeParentesco { get; set; }
    }

    public class ResponseIcatu
    {

        public ResponseIcatu()
        {
            GrauParentesco = new List<GrauParentescoResponse>();
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public List<GrauParentescoResponse> GrauParentesco { get; set; }
    }
}
