using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Converter;
using App.Interface;
using App.Result;
using App.Signature;
using Infra;
using Infra.Interface;
using Infra.Result;
using Infra.Signature;
using PI.Utility.Signature;
using Proxy.PortalInvestimentos.Interface;

namespace App
{
    public class PiApp : IPiApp
    {
        private readonly IPortalInvestimentoRepository _usuarioPiRepository;
        private readonly IPortalInvestimentosProxy _portalInvestimentosProxy;
        private readonly IPortalInvestimentoQaRepository _portalInvestimentoQaRepository;

        public PiApp(IPortalInvestimentoRepository usuarioPiRepository, IPortalInvestimentosProxy portalInvestimentosProxy , IPortalInvestimentoQaRepository portalInvestimentoQaRepository)
        {
            _usuarioPiRepository = usuarioPiRepository;
            _portalInvestimentosProxy = portalInvestimentosProxy;
            _portalInvestimentoQaRepository = portalInvestimentoQaRepository;
        }
   

        public async Task<IList<UsuarioPiResult>> ListaUsuarioAsync()
        {
            var usuarios = await _usuarioPiRepository.ObterListaUsuarioAsync();
            List<UsuarioPiResult> resultado = new List<UsuarioPiResult>();

            for(var i = 0; i < usuarios.Count ; i++)
            {
                var usuario = new UsuarioPiResult();
                usuario.CodUsuario = usuarios[i].CodUsuario;
                usuario.TipoUsuario = usuarios[i].TipoUsuario;
                usuario.TipoAutenticacao = usuarios[i].TipoAutenticacao;
                usuario.Role = usuarios[i].Role;
                usuario.CodExterno = usuarios[i].CodExterno;
                usuario.Nome = usuarios[i].Nome;
                usuario.Cpf = usuarios[i].Cpf;
                usuario.Login = usuarios[i].Login;
                usuario.Email = usuarios[i].Email;
                usuario.Ativo = usuarios[i].Ativo;
                
                resultado.Add(usuario);
            }
            return resultado;
        }
        
       public async Task<IList<TipoUsuarioResult>> ListaTipoUsuarioAsync()
       {
           var listaTipoUsuario = await _usuarioPiRepository.ObterListaTipoUsuarioAsync();
           List<TipoUsuarioResult> resultado = new List<TipoUsuarioResult>();

           for (var i = 0; i < listaTipoUsuario.Count; i++)
           {
               var tipoUsuario = new TipoUsuarioResult();
               tipoUsuario.Nome = listaTipoUsuario[i].Nome;
               tipoUsuario.CodTipoUsuario = listaTipoUsuario[i].CodTipoUsuario;
               resultado.Add(tipoUsuario);
           }
           return resultado;
       }

       public async Task<IList<TipoAutenticacaoResult>> ListaTipoAutenticacaoAsync()
       {
           var listaTipoUsuario = await _usuarioPiRepository.ObterListaTipoAutenticacaoAsync();
           List<TipoAutenticacaoResult> resultado = new List<TipoAutenticacaoResult>();

           for (var i = 0; i < listaTipoUsuario.Count; i++)
           {
               var tipoUsuario = new TipoAutenticacaoResult();
               tipoUsuario.Nome = listaTipoUsuario[i].Nome;
               tipoUsuario.CodTipoAutenticacao = listaTipoUsuario[i].CodTipoAutenticacao;
               resultado.Add(tipoUsuario);
           }
           return resultado;
       }

       public async Task<UsuarioPiResult> UsuarioPorCodigoClienteAsync(UsuarioSignature signature)
       {
           var result = await _usuarioPiRepository.ObterUsuarioPorCodigoUsuarioAsync(signature.CodUsuario);

           var usuario = new UsuarioPiResult();
           usuario.CodUsuario = result.CodUsuario;
           usuario.CodTipoUsuario = result.CodTipoUsuario;
           usuario.CodTipoAutenticacao = result.CodTipoAutenticacao;
           usuario.CodRole = result.CodRole;
           usuario.CodExterno = result.CodExterno;
           usuario.Nome = result.Nome;
           usuario.Cpf = result.Cpf;
           usuario.Login = result.Login;
           usuario.Email = result.Email;
           usuario.CodAtivo = result.CodAtivo;

           return usuario;
       }

       public async Task<int> AtualizarUsuarioAsync(EditarUsuarioSignature signature)
       {
           var usuario = await _usuarioPiRepository.ObterUsuarioPorCodigoUsuarioAsync(signature.CodUsuario);

           if (usuario != null)
           {
               var resultado = await _usuarioPiRepository.AtualizarUsuarioAsync(new EditarUSuarioRepositorySignature
               {
                   CodUsuario = signature.CodUsuario == 0 ? signature.CodUsuario : usuario.CodUsuario,
                   CodExterno = string.IsNullOrEmpty(signature.CodExterno) ? usuario.CodExterno : signature.CodExterno,
                   Nome = string.IsNullOrEmpty(signature.Nome) ? usuario.Nome : signature.Nome,
                   Cpf = string.IsNullOrEmpty(signature.Cpf) ? usuario.Cpf : signature.Cpf,
                   Ativo = signature.Ativo,
               });
               return resultado;
           }
           return 0;
       }

       public async Task<InfotreasuryResult> ObterStatusInfotreasury()
       {
          var infotreasury = await _usuarioPiRepository.ObterDataGiroInfotreasury();
          return new InfotreasuryResult { DataGiro = infotreasury.DataGiro , Message = "Ok" };
       }

       public async Task<LimparCacheResult> LimperCacheStage(LimparCacheSignature signature)
       {
           var limparCacheResult = new LimparCacheResult();
           try
           {
               limparCacheResult.CarteiraDeGerente = await _portalInvestimentosProxy.CarteiraDeGerentes(signature.Stage,signature.Ambiente);
               limparCacheResult.FundosRelacao = await _portalInvestimentosProxy.FundosRelacao(signature.Stage,signature.Ambiente);
               limparCacheResult.ListaDeProdutos = await _portalInvestimentosProxy.ListaDeProdutos(signature.Stage,signature.Ambiente);

           }catch(Exception ex)
           {
               return limparCacheResult;
           }           
           return limparCacheResult;
       }

        public async Task<PerfilResult> ObterPerfilCliente(PerfilSignature signature)
        {
            var perfil = await _usuarioPiRepository.ObterPerfilPorCodCliente(
                new PerfilRepositorySignature
                {
                    CodCliente = signature.CodCliente,
                });

            if(perfil == null)
            {
                return null;
            }

            var perfilResult = new PerfilResult();
            perfilResult.Documento = perfil.CGC_CPF;
            perfilResult.CodCliente = perfil.CODCLIENTE;
            perfilResult.PerfilVencido = perfil.PERFILVENCIDO;
            perfilResult.CodGerencial = perfil.CODCLASSIF_GERENCIAL;
            perfilResult.DataAtualizacao = perfil.DATAATUALIZACAO.ToString();
            perfilResult.CodPerfil = perfil.CODPERFIL;
            perfilResult.Base = perfil.BASE;

            return perfilResult;
        }

        public async Task<List<SituacaoResult>> ObterListaStatus()
        {
            var status = await _usuarioPiRepository.ObterStatus();
            return PortalInvestimentosConverter.ToListSituacaoResult(status);
        }
    }
}