using System.Collections.Generic;
using System.Threading.Tasks;
using App.Result;

namespace App.Interface
{
    public interface IAccessControlApp
    {
        public Task<List<RoleResult>> ObterListaRole();
        public Task<SsoResult> ObterTicketSSO();
        public Task<SsoResult> ObterTicketSSO(string codigoCliente);
        public Task<List<TokenResult>> ObterLoginToken();

    }
}