using System.Collections.Generic;
using System.Threading.Tasks;
using Proxy.AccessControl.Response;

namespace Proxy.AccessControl
{
    public interface IAccessControlProxy
    {
        public Task<List<RoleResultProxy>> ObterListaRolePortalInvestimentos();
        public Task<string> ObterTicket();

        public Task<string> ObterTicket(string CodCliente);
    }
}