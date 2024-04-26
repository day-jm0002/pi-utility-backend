using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Interface;
using App.Result;
using App.Signature;
using Microsoft.AspNetCore.Mvc;
using PI.Utility.Signature;

namespace PI.Utility.Controllers
{
    [ApiController]
    public class PortalInvestimentosController : ControllerBase
    {
        private readonly IPiApp _piApp;

        public PortalInvestimentosController(IPiApp piApp)
        {
            _piApp = piApp;
        }
        
        [HttpGet]
        [Route(nameof(ObterUsuariosPI))]
        public async Task<ActionResult<List<UsuarioPiResult>>> ObterUsuariosPI()
        {
            var usuarios = await this._piApp.ListaUsuarioAsync();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route(nameof(ObterStatusInfotreasury))]
        public async Task<ActionResult<InfotreasuryResult>> ObterStatusInfotreasury()
        {
            try
            {
                var info = await this._piApp.ObterStatusInfotreasury();
                return Ok(info);
            }catch(Exception ex)
            {
                return NotFound(new InfotreasuryResult { Message = ex.Message});
            }
        }

        [HttpPost]
        [Route(nameof(ObterUsuariosPIPorCodigoDeCliente))]
        public async Task<ActionResult<UsuarioPiResult>> ObterUsuariosPIPorCodigoDeCliente([FromBody]UsuarioSignature usuarioSignature)
        {
            var usuarios = await this._piApp.UsuarioPorCodigoClienteAsync(usuarioSignature);
            return Ok(usuarios);
        }

        [HttpGet]
        [Route(nameof(ObterTipoAutenticacao))]
        public async Task<ActionResult<TipoAutenticacaoResult>> ObterTipoAutenticacao()
        {
            var listaTipoAutenticacao = await this._piApp.ListaTipoAutenticacaoAsync();
            return Ok(listaTipoAutenticacao);
        }
        
        [HttpGet]
        [Route(nameof(ObterTipoUsuario))]
        public async Task<ActionResult<TipoUsuarioResult>> ObterTipoUsuario()
        {
            var listaTipoUsuario = await this._piApp.ListaTipoUsuarioAsync();
            return Ok(listaTipoUsuario);
        }

        [HttpPost]
        [Route(nameof(EditarUsuario))]
        public async Task<ActionResult<object>> EditarUsuario([FromBody]EditarUsuarioSignature edituarUsuarioSignature)
        {
            var resultado = await _piApp.AtualizarUsuarioAsync(edituarUsuarioSignature);

            if (resultado > 0)
            {
                var sucesso = new { Mensagem = "Usuário atualizado com sucesso", status = true };
                return Ok(sucesso);
            }
            else
            {
                var erro = new { Mensagem = "Não foi possível atualizar o usuário", status = false };
                return Ok(erro);
            }
        }

        [HttpPost]
        [Route(nameof(LimparCacheStage))]
        public async Task<ActionResult<LimparCacheResult>> LimparCacheStage([FromBody] LimparCacheSignature signature)
        {
            var result = await _piApp.LimperCacheStage(signature);
            return Ok(result);
        }


        [HttpPost]
        [Route(nameof(ObterPerfilSuitability))]
        public async Task<ActionResult<PerfilResult>> ObterPerfilSuitability([FromBody] PerfilSignature signature)
        {
            var result = await _piApp.ObterPerfilCliente(signature);            
            return Ok(result);
        }

        [HttpGet]
        [Route(nameof(ObterStatusSituacao))]
        public async Task<ActionResult<List<SituacaoResult>>> ObterStatusSituacao()
        {
            var lstDev = await _piApp.ObterListaStatus();
            return Ok(lstDev);
        }

    }
}