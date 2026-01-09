using Proxy.ApiCatalogRendaFixa.Interface;
using Proxy.ApiCatalogRendaFixa.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proxy.ApiCatalogRendaFixa
{
    public class ApiCatalogoRendaFixaProxy : IApiCatalogoRendaFixaProxy
    {
        public HttpClient _http { get; set; }
        public string Url { get; set; } = "http://sdaysp06d210:7359/api/v1/cache/";

        public ApiCatalogoRendaFixaProxy()
        {
            this._http = new HttpClient();
            this._http.DefaultRequestHeaders.Accept.Clear();
            this._http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/sjon"));

        }
       
        public async Task LimparCacheApiCatalogoGerentes()
        {
           await _http.PostAsync($"{this.Url}gerentes", null);
        }

        public async Task LimparCacheApiCatalogoLastros()
        {
            await _http.PostAsync($"{this.Url}lastro", null);
        }

        public async Task LimparCacheApiCatalogoProdutosBancarios()
        {
            await _http.PostAsync($"{this.Url}produtos-bancarios", null);
        }

        public async Task LimparCacheApiCatalogoProdutosPrivado()
        {
            await _http.PostAsync($"{this.Url}produtos-privados", null);
        }
    }
}
