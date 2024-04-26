using Proxy.PortalInvestimentos.Interface;
using Proxy.PortalInvestimentos.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.PortalInvestimentos
{
    public class PortalInvestimentosProxy : IPortalInvestimentosProxy
    {
        public HttpClient _http { get; set; }

        public PortalInvestimentosProxy()
        {
            this._http = new HttpClient();
            this._http.DefaultRequestHeaders.Accept.Clear();
            this._http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/sjon"));
            this. _http.Timeout = TimeSpan.FromMinutes(1);

        }

        public async Task<HttpStatusCode> FundosRelacao(string stage, string ambiente)
        {
            var url = UlrStage(stage, ambiente);
            var parametros = Parametros.FundosRelacao(new Parametros() { ChaveLiberacao = "c0bedab9-981f-436c-adc0-f5b326b2afde", Funcionalidade = "LISTARTERMOFUNDORELACAO" });
            var content = new StringContent(parametros, Encoding.UTF8, "application/json");
            var result = await _http.PostAsync(url, content);
            return result.StatusCode;
        }

        public async Task<HttpStatusCode> ListaDeProdutos(string stage, string ambiente)
        {
            var url = UlrStage(stage, ambiente);
            var parametros = Parametros.FundosRelacao(new Parametros() { ChaveLiberacao = "c0bedab9-981f-436c-adc0-f5b326b2afde", Funcionalidade = "DRIVEMNETLISTARPORTIFOLIO" });
            var content = new StringContent(parametros, Encoding.UTF8, "application/json");
            var result = await _http.PostAsync(url, content);
            return result.StatusCode;

        }

        public async Task<HttpStatusCode> CarteiraDeGerentes(string stage,string ambiente)
        {
            var url = UlrStage(stage,ambiente);
            var parametros = Parametros.FundosRelacao(new Parametros() { ChaveLiberacao = "c0bedab9-981f-436c-adc0-f5b326b2afde", Funcionalidade = "DRIVEMNETLISTARCARTEIRAGERENTE" });
            var content = new StringContent(parametros, Encoding.UTF8, "application/json");
            var result = await _http.PostAsync(url, content);
            return result.StatusCode;
        }

        private static string UlrStage(string stage,string ambiente)
        {
            if(ambiente == "dev")
            {
                if (stage == "StageOctopus")
                {
                    return $"http://sdaysp06d006/PortalInvestimentosApi/api/Sistema/LimparCacheAsync";
                }
                if(stage == "Stage4-DMZ")
                {
                    return $"http://sdaysp06d006/PortalInvestimentosApi/Stage4/api/Sistema/LimparCacheAsync";
                }

                return $"http://sdaysp06d006/PortalInvestimentosApi/{stage}/api/Sistema/LimparCacheAsync";
            }
           
            return $"http://sdaysp06qa003:8080/PortalInvestimentosApi/api/Sistema/LimparCacheAsync";            
          
        }
    }
}
