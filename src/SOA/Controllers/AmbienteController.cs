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
        [Route("ObterAmbientes/{Sistema}")]
        public async Task<ActionResult<List<AmbienteResult>>> ObterAmbientes([FromRoute] SistemaSignature sistemaSignature)
        {
            var sistema = sistemaSignature;
            return await _ambienteApp.ObterTodos(sistema);
        }

        [HttpGet]
        [Route("ObterPacoteQa/{Sistema}")]
        public async Task<ActionResult<AmbienteResultQa>> ObterPacoteQa([FromRoute] SistemaSignature sistemaSignature)
        {
            var sistema = sistemaSignature;
            return await _ambienteApp.ObterPacoteQa(sistema);
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


        [HttpPost]
        [Route(nameof(AtualizarChamadoAmbientesQa))]
        public async Task<ActionResult> AtualizarChamadoAmbientesQa(AmbienteChamadoSignature ambienteQaSignature)
        {
            await _ambienteApp.AtualizarChamadoAmbienteQa(ambienteQaSignature);
            return Ok(true);
        }

        [HttpPost]
        [Route(nameof(LiberarChamadoAmbientesQa))]
        public async Task<ActionResult> LiberarChamadoAmbientesQa(AmbienteSignatureQa ambienteSignatureQa)
        {
            await _ambienteApp.LiberarChamadoAmbientesQa(ambienteSignatureQa);
            return Ok(true);
        }



    }
}
