using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.PortalInvestimentos.Interface
{
    public  interface IPortalInvestimentosProxy
    {
        Task<HttpStatusCode> FundosRelacao(string stage, string ambiente);
        Task<HttpStatusCode> ListaDeProdutos(string stage, string ambiente);
        Task<HttpStatusCode> CarteiraDeGerentes(string stage, string ambiente);

    }
}
