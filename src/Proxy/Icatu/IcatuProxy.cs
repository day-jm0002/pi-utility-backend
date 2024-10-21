using Newtonsoft.Json;
using Proxy.Icatu.Interface;
using Proxy.Icatu.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Icatu
{
    public class IcatuProxy : IIcatuProxy
    {
        public IcatuProxy()
        {
        }
        public async Task<ResponseIcatu> ObterGrauParentesco()
        {
            var _httpCliente = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api-sandbox.icatuseguros.com.br/comum/v1/parentescos");
            request.Headers.Add("Ocp-Apim-Subscription-Key", "52a2d5d518474fe78a43b9ecadc01498");
            request.Headers.Add("CodigoEmpresa", "0514");
            request.Headers.Add("Cookie", "incap_ses_1618_2441878=Dal1ZOyk/n5xL5lyl0p0FuDOD2cAAAAA9VZbowCVPqGn3JAuOCQcvA==; visid_incap_2441878=NzP6ALpNRW2hgELUHyKU1mrN8WYAAAAAQUIPAAAAAACYj+y5scLzx7paR4B8ect5");
            var response = await _httpCliente.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return new ResponseIcatu { Mensagem = response.StatusCode.ToString() , Sucesso = false };
            }
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GrauParentescoResponse>>(content);

            return new ResponseIcatu { GrauParentesco = result, Mensagem = await response.Content.ReadAsStringAsync(), Sucesso = true };           
        }
    }
}
