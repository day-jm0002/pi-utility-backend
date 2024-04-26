using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App.Result
{
    public class LimparCacheResult
    {
        public HttpStatusCode CarteiraDeGerente { get; set; } 
        public HttpStatusCode FundosRelacao     {get;set;}
        public HttpStatusCode ListaDeProdutos   {get;set;} 
    }
}
