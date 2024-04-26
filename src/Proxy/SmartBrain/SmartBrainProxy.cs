using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using Proxy.SmartBrain.Enum;
using Proxy.SmartBrain.Interface;
using Proxy.SmartBrain.Response;
using Proxy.SmartBrain.Signature;
using Proxy.SmartBrain.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SmartBrain
{
    public class SmartBrainProxy : ISmartBrainProxy
    {
        public HttpClient _http { get; set; }
        public SmartBrainProxy()
        {
            this._http = new HttpClient();
        }

        public async Task<dynamic> Autenticar()
        {
            var Username = "csh_SmartBrain";
            var Password = "DcSm8aAFMVZz4PM7NTjk";
            var authenticationString = $"{Username}:{Password}";
            var base64String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));

            _http.Timeout = TimeSpan.FromMinutes(3);
            _http.BaseAddress = new Uri("https://advisor-extrato.daycoval.dev.br");
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
            HttpResponseMessage response = await _http.GetAsync("api/v1/auth/login");
            string json = await response.Content.ReadAsStringAsync();
            var retorno = IsJson(json) ? JsonConvert.DeserializeObject<dynamic>(json) : json;
            return retorno;
        }

        private bool IsJson(string json)
        {
            try
            {
                JsonConvert.DeserializeObject<dynamic>(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task ObterRentabilidade()
        {
            var uri = "http://sdaysp06d022/RentabilidadeApi/api/EvolucaoRentabilidade/Carteira/5Indexadores";
            var inicio = DateTime.Now.Ticks;

            var signature = new EvolucaoCarteiraRentabilidadeSignature
            {
                CodigoExterno = "29567229805",
                CodigoCategoria = 0,
                CodigoEstrategia = 0,
                DataInicio = "2022-12-16",
                DataFim = "2023-11-16",
                CodigoIndexador1 = (int)IndexadorRentabilidadeEnum.Cdi,
                CodigoIndexador2 = (int)IndexadorRentabilidadeEnum.Ibovespa,
                CodigoIndexador3 = (int)IndexadorRentabilidadeEnum.DolarComercial,
                CodigoIndexador4 = (int)IndexadorRentabilidadeEnum.IPCA
            };
            var content = ObterBody(signature);

            var response = await GetRetryPolicy()
                      .ExecuteAsync(async () =>
                      {
                          return await _http.PostAsync(uri, content);

                      });

            var retorno = new CarteiraRentabilidadeResponse();

            if (response.IsSuccessStatusCode)
            {
                var teste = await response.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<CarteiraRentabilidadeResponse>(teste);
            }

        }

        private AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy.Handle<HttpRequestException>()
                   .OrResult<HttpResponseMessage>(r => r.StatusCode != HttpStatusCode.OK && r.StatusCode != HttpStatusCode.NotFound)
                   .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt * 2));
        }

        public StringContent ObterBody(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
        }
    }
}
