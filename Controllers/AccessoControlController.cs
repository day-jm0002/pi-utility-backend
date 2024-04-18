using System.Collections.Generic;
using System.Threading.Tasks;
using App.Interface;
using App.Result;
using App.Signature;
using Microsoft.AspNetCore.Mvc;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoControlController : Controller
    {
        private readonly IAccessControlApp _accessControlApp;        
        
        public AccessoControlController(IAccessControlApp accessControlApp)
        {
            this._accessControlApp = accessControlApp;
        }
       
        [HttpGet]
        [Route(nameof(ObterListaRole))]
        public async Task<ActionResult<RoleResult>> ObterListaRole()
        {
            var listaRole = await _accessControlApp.ObterListaRole();
            return Ok(listaRole);
        }


        [HttpPost]
        [Route(nameof(AutenticacaoSSO))]
        public async Task<ActionResult<SsoResult>> AutenticacaoSSO(PosiocaoSsoSignature signature)
        {
            var retorno = await _accessControlApp.ObterTicketSSO(signature.CodigoCliente);
            return Ok(retorno);
        }

        [HttpGet]
        [Route(nameof(ObterLoginToken))]
        public async Task<ActionResult<List<TokenResult>>> ObterLoginToken()
        {
            var lstToken = await _accessControlApp.ObterLoginToken();
            return Ok(lstToken);
        }



    }
}