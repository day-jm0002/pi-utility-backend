using Proxy.ApiCatalogRendaFixa.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.ApiCatalogRendaFixa.Interface
{
    public interface IApiCatalogoRendaFixaProxy
    {
        Task LimparCacheApiCatalogoProdutosPrivado();
        Task LimparCacheApiCatalogoProdutosBancarios();
        Task LimparCacheApiCatalogoLastros();
        Task LimparCacheApiCatalogoGerentes();
    }
}
