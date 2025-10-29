using System.Collections.Generic;
using System.Threading.Tasks;
using App.Converter;
using App.Interface;
using App.Result;
using Infra.Interface;
using Proxy.AccessControl;

namespace App
{
    public class AccessControlApp : IAccessControlApp
    {
        private readonly IAccessControlProxy _accessControlProxy;
        private readonly IAccessControlRepository _accessControlRepository;
        
        public AccessControlApp(IAccessControlProxy accessControlProxy, IAccessControlRepository accessControlRepository)
        {
            _accessControlProxy = accessControlProxy;
            _accessControlRepository = accessControlRepository;
        }
        
        public async Task<List<RoleResult>> ObterListaRole()
        {
            var listaRole = await _accessControlProxy.ObterListaRolePortalInvestimentos();
            return AccessControlConverter.RoleResultProxyToRoleResul(listaRole);
        }

        public async Task<List<TokenResult>> ObterLoginToken()
        {
            var lsttoken = await _accessControlRepository.ObterLoginPorToken();

            if(lsttoken != null)
            {
                var lstTokenResult = new List<TokenResult>();
                foreach (var item in lsttoken)
                {
                    var token = new TokenResult();
                    token.SerialToken = item.SerialToken;
                    token.Login = item.Login;
                    token.Descricao = item.Descricao;
                    token.Nome = item.Nome;
                    lstTokenResult.Add(token);
                }
                return lstTokenResult;
            }
           
            return new List<TokenResult> { };
          
        }

        public  async Task<SsoResult> ObterTicketSSO()
        {        
            var url = "http://sdaysp06d006:8083/loginSso?ticketSso=";
            var retorno = await _accessControlProxy.ObterTicket();
            var ssoResult = new SsoResult();
            ssoResult.Ticket = url+retorno;
            return ssoResult;
        }

        public async Task<SsoResult> ObterTicketSSO(string CodigoCliente)
        {
            var url = "https://portalinvestimentosint.daycoval.dev.br/loginSso?ticketSso=";
            var retorno = await _accessControlProxy.ObterTicket(CodigoCliente);
            var ssoResult = new SsoResult();
            ssoResult.Ticket = url + retorno;
            return ssoResult;
        }

    }
}