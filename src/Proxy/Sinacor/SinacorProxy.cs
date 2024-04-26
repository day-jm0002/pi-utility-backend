using Newtonsoft.Json;
using Proxy.Sinacor.Interface;
using Proxy.Sinacor.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Sinacor
{
    public sealed class SinacorProxy : ISinacorProxy
    {
        public HttpClient _http { get; set; }
        public SinacorProxy()
        {
            this._http = new HttpClient();
        }

        public async Task<SinacorProxyResult> Autenticar()
        {
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/sjon"));
            _http.Timeout = TimeSpan.FromMinutes(1);
            var result = await _http.GetAsync("http://10.11.10.39:80/services/negotiation/brokerServiceLogin/csh_rms_prod/Teste@01/127.0.0.1/DAYCOVAL");
            var json = await result.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<SinacorProxyResult>(json);
            return retorno;
        }
    }
}
