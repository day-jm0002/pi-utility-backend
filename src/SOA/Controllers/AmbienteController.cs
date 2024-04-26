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
    public class AmbienteController : ControllerBase
    {
        private readonly IAmbienteApp _ambienteApp;
        public AmbienteController(IAmbienteApp ambienteApp)
        {
            _ambienteApp = ambienteApp;
        }

        [HttpGet]
        [Route("ObterAmbientes")]
        public async Task<ActionResult<List<AmbienteResult>>> ObterAmbientes()
        {
            return await _ambienteApp.ObterTodos();
        }

        [HttpGet]
        [Route("ObterPacoteQa")]
        public async Task<ActionResult<AmbienteResultQa>> ObterPacoteQa()
        {
            return await _ambienteApp.ObterPacoteQa();
        }

        [HttpPost]
        [Route(nameof(AtualizarAmbientes))]
        public async Task<ActionResult> AtualizarAmbientes(AmbienteSignature ambienteSignature)
        {
            await _ambienteApp.AtualizarAmbiente(ambienteSignature);
            return Ok(true);
        }

        [HttpPost]
        [Route(nameof(AtualizarAmbientesQa))]
        public async Task<ActionResult> AtualizarAmbientesQa(AmbienteSignatureQa ambienteQaSignature)
        { 
            await _ambienteApp.AtualizarAmbienteQa(ambienteQaSignature);
            return Ok(true);
        }


    }
}
