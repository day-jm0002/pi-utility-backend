using App.Interface;
using App.Result;
using App.Signature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PI.Utility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoBancController : ControllerBase
    {
        private readonly IInfoBancApp _infoBancApp;
        public InfoBancController(IInfoBancApp infoBancApp)
        {
            _infoBancApp = infoBancApp;
        }

        [HttpGet]
        [Route(nameof(ObterGerentes))]
        public async Task<ActionResult<List<GerenteResult>>> ObterGerentes()
        {
            var gerentes = await this._infoBancApp.ObterListaGerentes();           
            return Ok(gerentes);
        }

        [HttpPost]
        [Route(nameof(ObterGerentePorCodExterno))]
        public async Task<ActionResult<GerenteResult>> ObterGerentePorCodExterno(GerenteSignature signature)
        {
            var gerente = await _infoBancApp.ObterGerente(signature);
            return gerente;
        }
    }
}
