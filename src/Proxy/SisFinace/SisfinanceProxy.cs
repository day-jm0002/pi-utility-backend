using Newtonsoft.Json;
using Proxy.SisFinace.Response;
using Proxy.SisFinace.Signature;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SisFinace
{
    public class SisfinanceProxy : ISisFinanceProxy
    {
        public async Task<SisfinanceResponse> Autenticar()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://sdaysp07h026/API_SISFINANCE/api/v2/geraToken");
            var body = Login.Credenciais(new Login() { login = "csh_sisfinance", password = "YfMvs1c0Tzv7hBDmhvHr" });
            var content = new StringContent(body,null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var resultado = await response.Content.ReadAsStringAsync();
            var sisfinance = JsonConvert.DeserializeObject<string>(resultado);
            return new SisfinanceResponse{token=sisfinance};
        }
    }

    /*
       var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "AMnetWebToken=eyJhbGciOiJIUzUxMiJ9.eyJ1c3ItaWQiOjE1MDg1ODY0ODIsImlzcyI6IlNpbnFpYSIsImNoYW5uZWwiOiJCQUNLT0ZGSUNFIiwiZXhwIjoxNjgzNjQzNTc0LCJzc24taWQiOjE1MTI2NDcyNTh9.2iNQDqOUFaxW2cR59dN-zlvzwP_aTg1v9nbR3tgzibTXssf5cXdkZiygiYxiqB2y5rsx6FAs80vKpWfCs4orUA");
            var body = Login.Autenticacao(new Login() { user = "csh_DriveAMnetapi", password = "IFppJXq0tyDlyuHZeiq9" });
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse content = await _rest.ExecuteAsync(request);
            var drive = JsonConvert.DeserializeObject<DriveAMnetResponse>(content.Content);
     */
}
